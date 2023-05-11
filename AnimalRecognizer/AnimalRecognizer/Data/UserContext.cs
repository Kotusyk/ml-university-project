using AnimalRecognizer.Model;
using Microsoft.EntityFrameworkCore;

namespace AnimalRecognizer.Data
{
    public class UserContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string buyerRoleName = "buyer";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";

            // adding roles
            Role adminRole = new Role { ID = 1, Name = adminRoleName };
            Role buyerRole = new Role { ID = 2, Name = buyerRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.ID };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, buyerRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);

        }
    }
}
