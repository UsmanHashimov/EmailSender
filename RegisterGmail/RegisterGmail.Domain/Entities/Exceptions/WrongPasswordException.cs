namespace RegisterGmail.Domain.Entities.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("Wrong password") { }
    }
}
