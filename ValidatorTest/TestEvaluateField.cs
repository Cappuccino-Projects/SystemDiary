using ModelValidator.Interfaces;

namespace ValidatorTest
{
    public sealed class TestEvaluateField : IEvaluateField
    {

        private readonly string? _value;
        private string? _errorMessage;

        public TestEvaluateField(string value)
        {
            _value = value;
        }

        public bool Check() =>
            !(_value == null || string.IsNullOrEmpty(_value));

        public string GetErrorMessage() 
            => _errorMessage ?? string.Empty;

        public void RegistMistake() => 
            _errorMessage = "Ошибка тестового поля!";
    }
}
