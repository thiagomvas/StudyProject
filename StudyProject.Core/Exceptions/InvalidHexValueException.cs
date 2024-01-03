namespace StudyProject.Core.Exceptions
{
    internal class InvalidHexValueException : Exception
    {
        public InvalidHexValueException()
        {
        }

        public InvalidHexValueException(string? message) : base(message)
        {
        }

        public InvalidHexValueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
