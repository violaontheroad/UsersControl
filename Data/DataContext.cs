using Test.Models;
using Microsoft.EntityFrameworkCore;
using Blog.Data.Mappings;

namespace Test.Data
{
    public class DataContext : DbContext
    {       
        
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlServer("Server=localhost,1433;Database=Test;User ID=sa;Password=1q2w3e4r@#$");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}