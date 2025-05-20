namespace Book.Application.Exceptions
{
    public sealed class ConcurrencyException : System.Exception
    {
        public ConcurrencyException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
