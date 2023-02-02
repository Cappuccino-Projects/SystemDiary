using ModelValidator.Interfaces;

namespace ModelValidator.Fields
{
    public sealed class PasswordDublicateEvaluateField : IEvaluateField
    {

        private readonly string? _passwordOriginal;
        private readonly string? _passwordDublicate;
        private string? _errorMessage;

        public PasswordDublicateEvaluateField(string original, string dublicate) 
        {
            _passwordOriginal = original;
            _passwordDublicate = dublicate;
        }

        public bool Check() =>
            !(string.IsNullOrEmpty(_passwordOriginal) 
            && string.IsNullOrEmpty(_passwordDublicate))
            && (_passwordDublicate == _passwordOriginal);

        public string GetErrorMessage() =>
            _errorMessage ?? string.Empty;

        public void RegistMistake() =>
            _errorMessage = "Пароли не валидны или не совпадают!";
    }
}
