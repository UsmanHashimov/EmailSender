using Microsoft.EntityFrameworkCore;
using RegisterGmail.Application.IRepositories;
using RegisterGmail.Domain.Entities.DTOs;
using RegisterGmail.Domain.Entities.Exceptions;
using RegisterGmail.Infrastructure.Persistence;

namespace RegisterGmail.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private ApplicationDBContext _dbContext;
        public LoginRepository(ApplicationDBContext dbContext)
            => _dbContext = dbContext;

        public async Task<string> Login(UserDTO user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser == null)
            {
                throw new WrongGmailException();
            }
            else if (existingUser.Password != user.Password)
            {
                throw new WrongPasswordException();
            }

            return "You logged in succesfully!";
        }
    }
}
