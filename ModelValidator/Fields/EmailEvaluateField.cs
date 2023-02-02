using ModelValidator.Interfaces;

namespace ModelValidator.Fields
{
    public sealed class EmailEvaluateField : IEvaluateField
    {

        private readonly string _email;
        private string? _errorMessage;

        public EmailEvaluateField(string email) 
        { 
            _email = email;
        }

        public bool Check() => true;

        public string GetErrorMessage() => 
            _errorMessage ?? string.Empty;

        public void RegistMistake() =>
            _errorMessage = "Ошибка E-Mail!";
    }
}
