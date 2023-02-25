using Cappuccino.SystemDiary.Factories.Abstract;
using Models.Groups;

namespace Cappuccino.SystemDiary.Factories.Factories
{
    public sealed class GroupStateFactory : FactoryAbstract
    {
        private List<GroupStateModel> groupStateModels = new();

        public List<GroupStateModel> GroupStateModels 
        { 
            get => groupStateModels; 
            set => groupStateModels = value; 
        }

        public override void Create()
        {
            groupStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Активная группа",
                Description = "Эта группа активная"
            });

            groupStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Удалённая группа",
                Description = "Эта группа удалена"
            });
        }
    }
}
