using Models.Auth;
using ModelValidator.Fields;
using ModelValidator.Interfaces;

namespace ModelValidator.ModelsValidator
{
    public sealed class RegistrationModelValidator : IModelValidator
    {

        private Queue<IEvaluateField> _validFields = new Queue<IEvaluateField>();

        public RegistrationModelValidator(RegistrationFormModel registration)
        {
            _validFields.Enqueue(new LoginEvaluateField(registration.Login));
            _validFields.Enqueue(new PasswordEvaluateField(registration.PasswordOriginal));
            _validFields.Enqueue(new PasswordEvaluateField(registration.PasswordDoublicate));
            _validFields.Enqueue(new PasswordDublicateEvaluateField(registration.PasswordOriginal, registration.PasswordDoublicate));
            _validFields.Enqueue(new NameEvaluateField(registration.Name));
            _validFields.Enqueue(new NameEvaluateField(registration.FatherName));
            _validFields.Enqueue(new SurnameEvaluateField(registration.Surname));
            _validFields.Enqueue(new EmailEvaluateField(registration.Email));
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
