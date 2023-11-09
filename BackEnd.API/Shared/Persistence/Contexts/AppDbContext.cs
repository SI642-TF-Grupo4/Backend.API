using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Nombre).IsRequired();
        builder.Entity<User>().Property(u => u.Apellido).IsRequired();
        builder.Entity<User>().Property(u => u.Dni).IsRequired().HasMaxLength(9);
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.Telefono).IsRequired().HasMaxLength(9);
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}