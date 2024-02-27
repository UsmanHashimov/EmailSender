using Microsoft.EntityFrameworkCore;
using RegisterGmail.Application.IRepositories;
using RegisterGmail.Domain.Entities.DTOs;
using RegisterGmail.Domain.Entities.Exceptions;
using RegisterGmail.Domain.Entities.Models;
using RegisterGmail.Infrastructure.Persistence;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace RegisterGmail.Infrastructure.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private ApplicationDBContext _dbContext;
        private readonly IConfiguration _config;
        public RegisterRepository(ApplicationDBContext dBContext, IConfiguration config)
        {
            _dbContext = dBContext;
            _config = config;
        }

        public async Task<string> Register(UserDTO user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser != null)
            {
                throw new GmailExistsException();
            }

            Random random = new Random();
            var verCode = $"{random.Next(1000, 9999)}";

            var tempUser = new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                confirmPassword = verCode
            };

            await _dbContext.AddAsync(tempUser);
            await _dbContext.SaveChangesAsync();

            var emailSettings = _config.GetSection("EmailSettings");

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = "confirm",
                Body = $"<h1> Verification code: {verCode}</h1>",
                IsBodyHtml = true,

            };
            mailMessage.To.Add(user.Email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync(mailMessage);

            return "Verification code sent.";
        }

        public async Task<string> VerifyUser(string email, string verificationCode)
        {
            var tempUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (tempUser == null)
            {
                return "Invalid request.";
            }

            if (tempUser.confirmPassword == verificationCode)
            {
                var user = new User()
                {
                    UserName = tempUser.UserName,
                    Email = tempUser.Email,
                    Password = tempUser.Password,
                };

                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return "User registered successfully.";
            }

            return "Incorrect code";
        }

    }
}
