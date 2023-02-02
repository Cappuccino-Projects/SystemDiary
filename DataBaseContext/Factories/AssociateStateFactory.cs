using DataBaseContext.Abstract;
using Models.Associations;

namespace DataBaseContext.Factories
{
    public sealed class AssociateStateFactory : FactoryAbstract
    {
        private List<AssociateStateModel> associateStateModels = new();

        public List<AssociateStateModel> AssociateStateModels 
        { 
            get => associateStateModels; 
            set => associateStateModels = value; 
        }

        public override void Create()
        {
            associateStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Ассоциация активна",
                Description = "Эта ассоциация активна"
            });

            associateStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Ассоциация удалена",
                Description = "Этой ассоциации не существует"
            });
        }
    }
}
