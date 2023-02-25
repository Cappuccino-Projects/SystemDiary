using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cappuccino.SystemDiary.WebAPI.Options;
using DataBaseContext.Interfaces;
using Forms.Auth;
using Forms.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Users;
using ModelValidator.ModelsValidator;

namespace Cappuccino.SystemDiary.WebAPI.Controllers.Public.Auth
{
    /// <summary>
    /// Контроллер отвечающий за авторизацию, 
    /// регистрацию, выдачу токена восстановления
    /// </summary>
    [Route("api/public/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IDataBaseContext _context;
        private readonly IOptions<JWTOptions> _jwtOption;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        /// <param name="jwtOption">Опции JWT токена</param>
        public LoginController(IDataBaseContext context, IOptions<JWTOptions> jwtOption)
        {
            _context = context;
            _jwtOption = jwtOption;
        }

        /// <summary>
        /// Обработчик запроса на авторизацию<br/>
        /// <remarks>
        /// POST: api/public/auth/login
        /// </remarks>
        /// </summary>
        [EnableCors]
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromForm] AuthirizationFormModel authirization)
        {
            IActionResult result = BadRequest("Неизвестная ошибка!");

            AuthirizationModelValidator validator =
                new AuthirizationModelValidator(authirization);

            /*
             *  Validate - метод валидации формы, принимает в аргументы два
             *  делигата, первый - одработчик при удачной валидации
             *  второй для неудачной валидации
             */
            validator.Validate(
                () =>
                {
                    var user = _context.GetUsers()?
                        .Where(user => ((user.Email == authirization.Login) ||
                                        (user.Login == authirization.Login)) &&
                                        (user.Password == authirization.Password))
                        .First();

                    if (user == null)
                    {
                        result = BadRequest("Пользователь не найден!");
                        return;
                    }

                    string backedName = _context
                        .GetUserRoles()?
                        .Where(u => u.Id == _context.GetUsers()
                            .Where(u => u.PublicId == user.PublicId)
                            .Select(u => u.RoleId)
                            .FirstOrDefault())
                        .First().BackendName ?? String.Empty;

                    var roleName = _context
                        .GetUserRoles()
                        .Where(r => r.Id == user.RoleId)
                        .First()
                        .Name;

                    var token = GenerateJWTToken(user, backedName, _jwtOption.Value);
                    var refresh = GenerateRefreshToken(user, backedName, _jwtOption.Value);

                    _context.GetRefreshTokens().Add(new()
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        Token = refresh,
                        Created = DateTime.Now,
                        Expires = DateTime.Now.AddSeconds(_jwtOption.Value.RefreshLifetime),
                        IsActive = true
                    });

                    _context.Save();

                    result = Ok(new
                    {
                        access_token = token,
                        refresh_token = refresh,
                        user_name = user.Name,
                        user_surname = user.Surname,
                        user_fatherName = user.Fathername,
                        user_role = roleName
                    });

                },
                (message) =>
                    result = BadRequest(message));

            return result;
        }

        /// <summary>
        /// Обработчик запроса refresh<br/>
        /// <remark>
        /// POST: api/public/auth/refresh
        /// </remark>
        /// </summary>
        [EnableCors]
        [HttpPost("refresh"), Authorize]
        public IActionResult RefreshToken([FromForm] RefreshForm refresh)
        {
            /*
             *  Проверяем форму refresh, проверяем не пуст ли RefreshToken
             *  и AccessToken, если токены пусты вернём неудачный запрос 
             */
            if (string.IsNullOrEmpty(refresh.RefreshToken) || string.IsNullOrEmpty(refresh.AccessToken))
                return BadRequest("Пара токенов пустая! Запрос невозможен.");

            /*
             *  token - переменная хнанящая значение refresh токена
             */
            var token = _context
                .GetRefreshTokens()
                .Where(t => t.Token == refresh.RefreshToken)
                .First();

            /*
             *  user - переменная хранящая пользователя
             */
            var user = _context
                .GetUsers()
                .Where(u => u.Id == token.UserId)
                .First();

            /*
             *  backedName - название роли для backend
             */
            var backendName = _context
                .GetUserRoles()
                .Where(r => r.Id == user.RoleId)
                .First()
                .Name;

            var access_token = GenerateJWTToken(user, backendName, _jwtOption.Value);
            var refresh_token = GenerateRefreshToken(user, backendName, _jwtOption.Value);

            token.IsActive = false;

            _context.GetRefreshTokens()
                    .Add(new()
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        Token = refresh_token,
                        Created = DateTime.Now,
                        Expires = DateTime.Now.AddSeconds(_jwtOption.Value.RefreshLifetime),
                        IsActive = true
                    });

            _context.Save();

            return Ok(new
            {
                access_token = access_token,
                refresh_token = refresh_token
            });
        }

        [NonAction]
        private string GenerateJWTToken(UserModel? user, string backendName, JWTOptions options)
        {
            var securityKey = options.GetSymmericSecurityToken();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userRole = _context.GetUserRoles()
                .Where(u => u.Id == user.RoleId)
                .First().Name;

            var claims = new List<Claim>()
            {
                new Claim("user_private_id", user?.Id.ToString() ?? ""),
                new Claim("user_role_name", backendName),
                new Claim(ClaimTypes.Role, userRole)
            };

            var token = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(options.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

        [NonAction]
        private string GenerateRefreshToken(UserModel? user, string backendName, JWTOptions options)
        {

            var securityKey = options.GetSymmericSecurityToken();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userRole = _context.GetUserRoles()
                .Where(u => u.Id == user.RoleId)
                .First().Name;

            var refresh = new List<Claim>()
            {
                new Claim("user_private_id", user?.Id.ToString() ?? ""),
                new Claim("user_role_name", backendName),
                new Claim(ClaimTypes.Role, userRole)
            };

            var refreshToken = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                refresh,
                expires: DateTime.Now.AddSeconds(options.RefreshLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(refreshToken);

        }
    }
}
