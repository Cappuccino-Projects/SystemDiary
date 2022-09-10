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
        public IActionResult Login([FromForm] Authirization authirization)
        {
            IActionResult result = BadRequest("Неизвестная ошибка!");

            AuthirizationModelValidator validator =
                new AuthirizationModelValidator(authirization);

            validator.Validate(
                async () =>
                {
                    var user = _context.GetUsers()?
                        .Where(user => ((user.Email == authirization.Login) ||
                                        (user.Login == authirization.Login)) &&
                                        (user.Password == authirization.Password))
                        .FirstOrDefault();

                    result = (user == null) ?
                        BadRequest("Пользователь не найден!") : Ok();

                    if (user != null)
                        await Authenticate(user.PublicId);
                },
                (message) => result = BadRequest(message));


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
                () =>
                {
                    if (_context.GetUsers()?.Count() == 0)
                        _context.CreateDefaultValues();

                    if (CheckUserDataForUniqueness(registration))
                    {
                        result = Ok();
                        CreateNewRecord(registration);
                    }
                    else
                    {
                        result = BadRequest("Данные пользователя уже есть в базе");
                    }
                },
                (message) => result = BadRequest(message));

            return result;
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        #region AdditionalMethods

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
                Gender = registration.Gender,
                Age = registration.Age,
                Email = registration.Email,
                Login = registration.Login,
                Password = registration.PasswordOriginal,
                RoleId = (_context.GetUsers()?.Count() == 0) ? GetAdminRoleId() : GetStudentRoleId(),
                StateId = GetActiveState(),
                LastSession = DateTime.Now
            };

            _context.GetUsers()?
                .Add(user);

            _context.Save();
        }

        [NonAction]
        private Guid GetStudentRoleId()
        {
            return _context.GetUserRoles()
                .Where(u => u.BackendName == "backend_student").FirstOrDefault().Id;
        }

        [NonAction]
        private Guid GetAdminRoleId()
        {
            return _context.GetUserRoles()
                .Where(u => u.BackendName == "backend_admin").FirstOrDefault().Id;
        }

        [NonAction]
        private Guid GetActiveState()
        {
            return _context.GetUserStates().ToList()[0].Id;
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

        #endregion
    }
}
