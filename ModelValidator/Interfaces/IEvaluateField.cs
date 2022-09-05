namespace ModelValidator.Interfaces
{
    public interface IEvaluateField
    {
        public bool Check();
        public void Interrupt();
        public string GetErrorMessage();
    }
}
