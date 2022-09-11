using Models.Authirization;
using ModelValidator.Fields;
using ModelValidator.Interfaces;

namespace ModelValidator.ModelsValidator
{
    public sealed class AuthirizationModelValidator : IModelValidator
    {

        private Queue<IEvaluateField> _validFields = new Queue<IEvaluateField>();

        public AuthirizationModelValidator(AuthirizationFormModel authirization)
        {
            _validFields.Enqueue(new LoginEvaluateField(authirization.Login));
            _validFields.Enqueue(new PasswordEvaluateField(authirization.Password));
        }

        public void Validate(Action OnSuccess, Action<string> OnFailed)
        {
            foreach (var field in _validFields)
            {
                bool isValid = field.Check();

                if (!isValid)
                {
                    field.RegistMistake();
                    OnFailed(field.GetErrorMessage());
                    return;
                }
            }
            OnSuccess();
        }
    }
}
