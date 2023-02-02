using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Forms.Auth;
using Models.Users;
using ModelValidator.ModelsValidator;
using System.Security.Claims;

namespace WebAPI.Controllers.Auth
{
    [Route("api/auth/admin")]
    [ApiController]
    public sealed class RegistrationController : ControllerBase
    {

        private readonly IDataBaseContext _context;

        public RegistrationController(IDataBaseContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public IActionResult Registration([FromForm] RegistrationFormModel registration)
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
                        result = Ok("Пользователь успешно добавлен!");
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

        #region AdditionalMethods

        [NonAction]
        private void CreateNewRecord([FromForm] RegistrationFormModel registration)
        {
            var user = new UserModel()
            {
                Id = Guid.NewGuid(),
                PublicId = Guid.NewGuid(),
                Name = registration.Name,
                Surname = registration.Surname,
                Fathername = registration.FatherName,
                Gender = registration.Gender,
                Email = registration.Email,
                Birth = registration.Birth,
                Login = registration.Login,
                Password = registration.PasswordOriginal,
                RoleId = (_context.GetUsers()?.Count() == 0) ? GetAdminRoleId() : GetStudentRoleId(),
                StateId = GetActiveState()
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
            return _context.GetUserStates().Where(s => s.Name == "Активный").First().Id;
        }

        [NonAction]
        private bool CheckUserDataForUniqueness(RegistrationFormModel registration)
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


        #endregion
    }
}
