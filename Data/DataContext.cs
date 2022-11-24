using Test.Models;
using Microsoft.EntityFrameworkCore;
using Blog.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using SecureIdentity.Password;

namespace Test.Data
{
    public class DataContext : DbContext
    {       
        
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            this.SeedUser(modelBuilder);
        }

        private void SeedUser(ModelBuilder modelBuilder){

            var password = "12345";
            var passwordHasher = PasswordHasher.Hash(password);
            User user = new User()
            {
                Id = 1,
                Name = "Viola",
                Email = "viola@gmail.com",
                Cpf = "123.123.123-11",
                Password = passwordHasher

            };
  
            modelBuilder.Entity<User>().HasData(user);
            
        }
    }
}