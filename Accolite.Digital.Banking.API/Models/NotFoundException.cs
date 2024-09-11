namespace Accolite.Digital.Banking.API.Models
{
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Constructor that takes a message
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public NotFoundException(string message) : this(message, null) { }

        /// <summary>
        /// Constructor that takes a message
        /// </summary>
        /// <param name="message">The message of the exception</param>
        /// <param name="innerException">The inner exception</param>
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
