using Models.Abstract;
using Models.Authirization;
using ModelValidator.Interfaces;

namespace ModelValidator
{
    public class Validator
    {
        private readonly FormAbstract _model;
        public Action? OnSuccess;
        public Action<string>? OnFailed;

        public Validator(FormAbstract model)
        {
            _model = model;
        }

        public void CompareWith(IModelValidator model)
        {
            model.Validate(
                () => OnSuccess?.Invoke(),
                (m) => OnFailed?.Invoke(m));
        }
    }
}