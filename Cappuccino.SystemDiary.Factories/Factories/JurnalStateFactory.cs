using Cappuccino.SystemDiary.Factories.Abstract;
using Models.Journal;

namespace Cappuccino.SystemDiary.Factories.Factories
{
    public sealed class JurnalStateFactory : FactoryAbstract
    {
        private List<JournalStateModel> _jurnalStateModels = new();

        public List<JournalStateModel> JurnalStateModels 
        { 
            get => _jurnalStateModels; 
            set => _jurnalStateModels = value; 
        }

        public override void Create()
        {
            _jurnalStateModels.Add(new() 
            {
                Id = Guid.NewGuid(),
                Name = "Активное состояние",
                Description = "Актиное состояние журнала"
            });

            _jurnalStateModels.Add(new() 
            {
                Id = Guid.NewGuid(),
                Name = "Неактивное состояние",
                Description = "Неактиное состояние журнала"
            });
        }
    }
}
