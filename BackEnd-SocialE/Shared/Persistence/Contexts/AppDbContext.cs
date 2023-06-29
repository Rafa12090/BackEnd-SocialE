using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SocialE.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
    public DbSet<Event> Events { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Event>().ToTable("Events");
        modelBuilder.Entity<Event>().HasKey(p=>p.Id);
        modelBuilder.Entity<Event>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Event>().Property(p => p.Name).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.Description).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.Price).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.EventDate).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.StartTime).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.EndTime).IsRequired().HasMaxLength(120);
        //Añadir relaciones
        
        //Cambiar syntax
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}