namespace RegisterGmail.Domain.Entities.Exceptions
{
    public class WrongGmailException : Exception
    {
        public WrongGmailException() : base("This is email not registered! Try to register") { }
    }
}
