using Cappuccino.SystemDiary.Factories.Abstract;
using Cappuccino.SystemDiary.Factories.Others;
using Models.Users;

namespace Cappuccino.SystemDiary.Factories.Factories
{
    public sealed class UserRoleFactory : FactoryAbstract
    {
        private List<UserRoleModel> _userRoleModels = new();

        public IReadOnlyCollection<UserRoleModel> UserRoleModels => _userRoleModels;

        public override void Create()
        {
            _userRoleModels.Add(new UserRoleModel
            {
                Id = Guid.NewGuid(),
                Name = ConstantName.Administrator,
                Description = "Администратор системы SystemDiary",
                BackendName = "backend_admin"
            });

            _userRoleModels.Add(new UserRoleModel
            {
                Id = Guid.NewGuid(),
                Name = ConstantName.Teacher,
                Description = "Преподаёт",
                BackendName = "backend_teacher"
            });

            _userRoleModels.Add(new UserRoleModel
            {
                Id = Guid.NewGuid(),
                Name = ConstantName.Student,
                Description = "Тот кто обучается",
                BackendName = "backend_student"
            });

            _userRoleModels.Add(new UserRoleModel
            {
                Id = Guid.NewGuid(),
                Name = ConstantName.Operator,
                Description= "Разработчик расписания",
                BackendName = "backend_operator"
            });
        }
    }
}
