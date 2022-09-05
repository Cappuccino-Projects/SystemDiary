using Models.Auth;
using ModelValidator.Fields;
using ModelValidator.Interfaces;

namespace ModelValidator.ModelsValidator
{
    public sealed class RegistrationModelValidator : IModelValidator
    {

        private Queue<IEvaluateField> _validFields = new Queue<IEvaluateField>();

        public RegistrationModelValidator(Registration registration) 
        {
            _validFields.Enqueue(new LoginEvaluateField(registration.Login));
            _validFields.Enqueue(new PasswordEvaluateField(registration.PasswordOriginal));
            _validFields.Enqueue(new PasswordEvaluateField(registration.PasswordDublicate));
            _validFields.Enqueue(new PasswordDublicateEvaluateField(registration.PasswordOriginal, registration.PasswordDublicate));
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

                if (isValid)
                {
                    OnSuccess();
                }
                else
                {
                    field.Interrupt();
                    OnFailed(field.GetErrorMessage());
                    return;
                }
            }
        }
    }
}
