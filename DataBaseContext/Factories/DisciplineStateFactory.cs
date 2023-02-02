using DataBaseContext.Abstract;
using Models.Disciplines;

namespace DataBaseContext.Factories
{
    public sealed class DisciplineStateFactory : FactoryAbstract
    {
        private List<DisciplineStateModel> disciplineStates = new();

        public List<DisciplineStateModel> DisciplineStates 
        { 
            get => disciplineStates; 
            set => disciplineStates = value; 
        }

        public override void Create() 
        {
            disciplineStates.Add(new() 
            {
                Id = Guid.NewGuid(),
                Name = "Активная",
                Description = "Дисциплина активная"
            });

            disciplineStates.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = "Удалена",
                Description = "Дисциплина удалена"
            });
        }
    }
}
