using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using Models.Authirization;
using Models.Users;
using ModelValidator.ModelsValidator;
using System.Security.Claims;

namespace WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthController : ControllerBase
    {

        private readonly IDataBaseContext _context;

        public AuthController(IDataBaseContext context) 
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] Authirization authirization) 
        {
            IActionResult result = BadRequest("Неизвестная ошибка!");

            AuthirizationModelValidator validator = 
                new AuthirizationModelValidator(authirization);

            validator.Validate(
                () => result = Ok(),
                (message) => result = BadRequest(message));

            var user = _context.GetUsers()?
                .Where(user => ((user.Email == authirization.Login) || (user.Login == authirization.Login)) && (user.Password == authirization.Password))
                .FirstOrDefault();

            result = (user == null) ? BadRequest("Пользователь не найден!") : Ok();
            
            if (user != null)
                await Authenticate(user.PublicId);

            return result;
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public IActionResult Registration([FromForm] Registration registration)
        {
            IActionResult result = BadRequest("Неизвестная ошибка!");

            RegistrationModelValidator validator =
                new RegistrationModelValidator(registration);

            validator.Validate(
                () => result = Ok(),
                (message) => result = BadRequest(message));

            result = CheckUserDataForUniqueness(registration) ? 
                Ok() : BadRequest("Данные пользователя уже есть в базе");

            CreateNewRecord(registration);

            return result;
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [NonAction]
        private void CreateNewRecord(Registration registration)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                PublicId = Guid.NewGuid(),
                Name = registration.Name,
                Surname = registration.Surname,
                Fathername = registration.FatherName,
                Age = 0,
                Email = registration.Email,
                Login = registration.Login,
                Password = registration.PasswordOriginal
            };

            _context.GetUsers()?
                .Add(user);
        }

        [NonAction]
        private bool CheckUserDataForUniqueness(Registration registration)
        {
            return UserEmailIsNotExist(registration.Email) 
                && UserLoginIsNotExist(registration.Login);
        }

        [NonAction]
        private bool UserEmailIsNotExist(string email) 
        {
            return _context.GetUsers()?
                .Where(user => user.Email == email)
                .Count() == 0;
        }

        [NonAction]
        private bool UserLoginIsNotExist(string login) 
        {
            return _context.GetUsers()?.
                Where(user => user.Login == login)
                .Count() == 0;
        }
        
        [NonAction]
        public async Task Authenticate(Guid publicId)
        {
            if (publicId == Guid.Empty)
                return;

            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, publicId.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
