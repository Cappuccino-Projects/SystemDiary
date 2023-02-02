using DataBaseContext.Abstract;
using Models.Marks;

namespace DataBaseContext.Factories
{
    public sealed class MarkFactory : FactoryAbstract
    {
        private List<MarkModel> _markModels = new();
        private readonly List<MarkStateModel> _stateModels;

        public List<MarkModel> MarkModels 
        { 
            get => _markModels; 
            set => _markModels = value; 
        }

        public MarkFactory(List<MarkStateModel> stateModels) 
        {
            _stateModels = stateModels;
        }

        public override void Create()
        {
            _markModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Markup = "5",
                Value = 5,
                Description = "Оценка отлично",
                StateId = _stateModels
                    .First(i => i.Name == "Активная").Id
            });

            _markModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Markup = "4",
                Value = 4,
                Description = "Оценка хорошо",
                StateId = _stateModels
                    .First(i => i.Name == "Активная").Id
            });

            _markModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Markup = "3",
                Value = 3,
                Description = "Оценка удовлетворительно",
                StateId = _stateModels
                    .First(i => i.Name == "Активная").Id
            });

            _markModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Markup = "2",
                Value = 2,
                Description = "Оценка плохо",
                StateId = _stateModels
                    .First(i => i.Name == "Активная").Id
            });
        }
    }
}
