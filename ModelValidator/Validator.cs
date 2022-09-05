using Models.Abstract;
using Models.Authirization;
using ModelValidator.Interfaces;

namespace ModelValidator
{
    public class Validator
    {
        private readonly AbstractModel _model;
        public Action? OnSuccess;
        public Action<string>? OnFailed;

        public Validator(AbstractModel model)
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