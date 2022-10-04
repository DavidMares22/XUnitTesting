namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  

        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                   Id = 1,
                   Title = "Mr",
                   FirstName = "George",
                   LastName = "Costanza",
                   Role = Role.User,
                   Email = "george@costanza.com",
                   PasswordHash = "$2a$11$j9TSai7rHi6C3o2SuS275eoJfzUZRFwg/CPPGzD05KogqQvs4oTqi"
                } 
            );
    }

    public DbSet<User> Users { get; set; }
}