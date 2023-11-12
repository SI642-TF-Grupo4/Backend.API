using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

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
        builder.Entity<User>()
            .HasOne(u => u.Vehicle)
            .WithOne(v => v.User)
            .HasForeignKey<Vehicle>(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Vehicle>().ToTable("Vehicles");
        builder.Entity<Vehicle>().HasKey(v => v.Id);
        builder.Entity<Vehicle>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(v => v.Marca).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Modelo).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Monto).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Placa).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Tipo);

        builder.UseSnakeCaseNamingConvention();
    }
}