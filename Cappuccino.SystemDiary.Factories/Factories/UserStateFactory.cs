using Cappuccino.SystemDiary.Factories.Abstract;
using Models.Users;

namespace Cappuccino.SystemDiary.Factories.Factories
{
    public sealed class UserStateFactory : FactoryAbstract
    {
        private List<UserStateModel> _userStates = new();

        public IReadOnlyCollection<UserStateModel> UserStates => _userStates;

        public override void Create()
        {
            _userStates.Add(new UserStateModel()
            {
                Id = Guid.NewGuid(),
                Name = "Активный",
                Description = "Работоспособный аккаунт"
            });

            _userStates.Add(new UserStateModel() {
                Id = Guid.NewGuid(),
                Name = "Не активный",
                Description = "Аккаунт не активный"
            });
        }
    }
}
