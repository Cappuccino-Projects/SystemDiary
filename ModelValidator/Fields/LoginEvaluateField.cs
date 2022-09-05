using ModelValidator.Interfaces;

namespace ModelValidator.Fields
{
    public sealed class LoginEvaluateField : IEvaluateField
    {
        private readonly string _value;
        private string? _errorMessage;

        public LoginEvaluateField(string value) 
        {
            _value = value;
        }

        public bool Check() =>
            !string.IsNullOrEmpty(_value);

        public string GetErrorMessage() =>
            _errorMessage ?? string.Empty;

        public void Interrupt() =>
            _errorMessage = "Поле логина не валидно!";
    }
}
