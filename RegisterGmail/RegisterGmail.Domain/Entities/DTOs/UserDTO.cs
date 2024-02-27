using System.ComponentModel.DataAnnotations;

namespace RegisterGmail.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public required string UserName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }

    }
}
