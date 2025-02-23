namespace OngsPet.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : OngsPetException
    {

        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
