using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Credito> Creditos { get; set; }
    
    public DbSet<Entidad> Entidades { get; set; }
    public DbSet<Cuota> Cuotas { get; set; }

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
        builder.Entity<User>().Property(u => u.Password).IsRequired();
        builder.Entity<User>()
            .HasOne(u => u.Vehicle)
            .WithOne(v => v.User)
            .HasForeignKey<Vehicle>(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<User>()
            .HasOne(u => u.Credito)
            .WithOne(c => c.User)
            .HasForeignKey<Credito>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Vehicle>().ToTable("Vehicles");
        builder.Entity<Vehicle>().HasKey(v => v.Id);
        builder.Entity<Vehicle>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(v => v.Marca).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Modelo).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Monto).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Placa).IsRequired();
        builder.Entity<Vehicle>().Property(v => v.Tipo);

        builder.Entity<Credito>().ToTable("Creditos");
        builder.Entity<Credito>().HasKey(c => c.Id);
        builder.Entity<Credito>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Credito>().Property(c => c.PrecioVenta);
        builder.Entity<Credito>().Property(c => c.CuotaInicial);
        builder.Entity<Credito>().Property(c => c.MontoFinanciar);
        builder.Entity<Credito>().Property(c => c.MontoSolicitar);
        builder.Entity<Credito>().Property(c => c.Plazo);
        builder.Entity<Credito>().Property(c => c.TipoGracia);
        builder.Entity<Credito>().Property(c => c.TotalPeriodos);
        builder.Entity<Credito>().Property(c => c.TipoTasa);
        builder.Entity<Credito>().Property(c => c.Tea);
        builder.Entity<Credito>().Property(c => c.Tna);
        builder.Entity<Credito>().Property(c => c.Tem);
        builder.Entity<Credito>().Property(c => c.Moneda);
        builder.Entity<Credito>().Property(c => c.PeriodosGraciaParcial);
        builder.Entity<Credito>().Property(c => c.PeriodosGraciaTotal);
        builder.Entity<Credito>().Property(c => c.TasaSeguroDesgravamen);
        builder.Entity<Credito>().Property(c => c.TasaInteresMoratorio);
        builder.Entity<Credito>().Property(c => c.ComisionEnvioFisico);
        builder.Entity<Credito>().Property(c => c.TasaSeguroVehicular);
        builder.Entity<Credito>().Property(c => c.FechaPrimeraCuota);
        builder.Entity<Credito>().Property(c => c.FechaDesembolso);
        builder.Entity<Credito>().Property(c => c.OtrosGastos);
        builder.Entity<Credito>().Property(c => c.Comision);
        builder.Entity<Credito>().Property(c => c.Tir);
        builder.Entity<Credito>().Property(c => c.Tcea);
        builder.Entity<Credito>().Property(c => c.CuotaMensual);
        builder.Entity<Credito>().Property(c => c.UltimaCuota);
        
        builder.Entity<Cuota>().ToTable("Cuotas");
        builder.Entity<Cuota>().HasKey(c => c.Id);
        builder.Entity<Cuota>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Cuota>().Property(c => c.NCuota);
        builder.Entity<Cuota>().Property(c => c.Fecha);
        builder.Entity<Cuota>().Property(c => c.TipoPeriodoGracia);
        builder.Entity<Cuota>().Property(c => c.SaldoInicial);
        builder.Entity<Cuota>().Property(c => c.Interes);
        builder.Entity<Cuota>().Property(c => c.Amortización);
        builder.Entity<Cuota>().Property(c => c.FlujoDeCaja);
        builder.Entity<Cuota>().Property(c => c.MontoCuota);
        builder.Entity<Cuota>().Property(c => c.SaldoFinal);
        builder.Entity<Cuota>().Property(c => c.Comision);
        builder.Entity<Cuota>().Property(c => c.SeguroDesgravamen);
        builder.Entity<Cuota>().Property(c => c.SeguroVehicular);

        builder.Entity<Credito>().HasMany(
                c => c.PlanDePago
            ).WithOne(c => c.Credito)
            .HasForeignKey(c => c.CreditoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Entidad>().ToTable("Entidades");
        builder.Entity<Entidad>().Property(e => e.Id);
        builder.Entity<Entidad>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Entidad>().Property(e => e.Name);
        builder.Entity<Entidad>().Property(e => e.Comision);
        builder.Entity<Entidad>().Property(e => e.SeguroDeg);
        builder.Entity<Entidad>().Property(e => e.SeguroVehi);
        builder.Entity<Entidad>().Property(e => e.TasaMin);
        builder.Entity<Entidad>().Property(e => e.TasaMax);
        
        builder.UseSnakeCaseNamingConvention();
    }
}