using DataBaseContext.Abstract;
using Models.Users;

namespace DataBaseContext.Factories
{
    public sealed class UserRoleFactory : FactoryAbstract
    {
        private List<UserRoleModel> userRoleModels = new();

        public List<UserRoleModel> UserRoleModels { get => userRoleModels; set => userRoleModels = value; }

        public override void Create()
        {
            userRoleModels.Add(new() 
            {
                Id = Guid.NewGuid(),
                Name = "Администратор",
                Description = "Администратор системы SystemDiary",
                BackendName = "backend_admin"
            });

            userRoleModels.Add(new() 
            {
                Id = Guid.NewGuid(),
                Name = "Преподаватель",
                Description = "Препадаёт",
                BackendName = "backend_teacher"
            });

            userRoleModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Студент",
                Description = "Тот кто обучается",
                BackendName = "backend_student"
            });

            userRoleModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Оператор",
                Description= "Разработчик расписания",
                BackendName = "backend_operator"
            });
        }
    }
}
