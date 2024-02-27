using Microsoft.EntityFrameworkCore;
using RegisterGmail.Domain.Entities.Models;

namespace RegisterGmail.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
            => Database.Migrate();

        public virtual DbSet<User> Users { get; set; }
    }
}
