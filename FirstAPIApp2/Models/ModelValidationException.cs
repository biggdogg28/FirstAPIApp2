namespace FirstAPIApp2.Models
{
    // any custom exception must inherit from the Exception base class
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message) : base(message) { }
    }
}
