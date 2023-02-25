using Cappuccino.SystemDiary.Factories.Abstract;
using Models.Marks;

namespace Cappuccino.SystemDiary.Factories.Factories
{
    public sealed class MarkStateFactory : FactoryAbstract
    {
        private List<MarkStateModel> markStateModels = new();

        public List<MarkStateModel> MarkStateModels 
        { 
            get => markStateModels; 
            set => markStateModels = value; 
        }

        public override void Create()
        {
            markStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Активная",
                Description = "Оценка активная"
            });

            markStateModels.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Удалена",
                Description = "Оценка удалена, её использование не возможно"
            });
        }
    }
}
