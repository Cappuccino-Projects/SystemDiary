namespace ModelValidator.Interfaces
{
    public interface IEvaluateField
    {
        public bool Check();
        public void RegistMistake();
        public string GetErrorMessage();
    }
}
