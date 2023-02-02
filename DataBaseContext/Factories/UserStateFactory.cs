using DataBaseContext.Abstract;
using Models.Users;

namespace DataBaseContext.Factories
{
    public sealed class UserStateFactory : FactoryAbstract
    {
        private List<UserStateModel> userStates = 
            new List<UserStateModel>();

        public List<UserStateModel> UserStates 
        { 
            get => userStates; 
            set => userStates = value; 
        }

        public override void Create()
        {
            userStates.Add(new UserStateModel()
            {
                Id = Guid.NewGuid(),
                Name = "Активный",
                Description = "Работоспособный аккаунт"
            });

            userStates.Add(new UserStateModel() {
                Id = Guid.NewGuid(),
                Name = "Не активный",
                Description = "Аккаунт не активный"
            });
        }
    }
}
