using Cappuccino.SystemDiary.Factories.Abstract;
using Models.Associations;

namespace Cappuccino.SystemDiary.Factories.Factories
{
    public sealed class AssociateStateFactory : FactoryAbstract
    {
        private List<AssociateStateModel> _associateStateModels = new();

        public List<AssociateStateModel> AssociateStateModels 
        { 
            get => _associateStateModels; 
            set => _associateStateModels = value; 
        }

        public override void Create()
        {
            _associateStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Ассоциация активна",
                Description = "Эта ассоциация активна"
            });

            _associateStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Ассоциация удалена",
                Description = "Этой ассоциации не существует"
            });
        }
    }
}
