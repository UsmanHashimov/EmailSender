namespace RegisterGmail.Domain.Entities.Exceptions
{
    public class GmailExistsException : Exception
    {
        public GmailExistsException() : base("Gmail already exists") { }
    }
}
