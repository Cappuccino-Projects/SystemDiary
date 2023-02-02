using ModelValidator.Interfaces;

namespace ModelValidator.Fields
{
    public sealed class NameEvaluateField : IEvaluateField
    {

        private readonly string? _value;
        private string? _errorMessage;

        public NameEvaluateField(string value) 
        {
            _value = value;
        }

        public bool Check() =>
            !string.IsNullOrEmpty(_value);

        public string GetErrorMessage() =>
            _errorMessage ?? string.Empty;

        public void RegistMistake() =>
            _errorMessage = "Поле с Именем не валидно!";
    }
}
