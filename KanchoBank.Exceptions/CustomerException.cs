namespace KanchoBank.Exceptions
{
    /// <summary>
    /// This is exception class that represents errors in the customer class
    /// </summary>
    public class CustomerException:ApplicationException
    {
        /// <summary>
        /// Constructor initializes the exception message
        /// </summary>
        /// <param name="message">Exception Message</param>
        public CustomerException(string message):base(message)
        {
        }
        /// <summary>
        /// Constructor initialize message and inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner Exception </param>
        public CustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}