namespace ModelValidator.Interfaces
{
    public interface IModelValidator
    {
        public void Validate(Action OnSuccess, Action<string> OnFailed);
    }
}
