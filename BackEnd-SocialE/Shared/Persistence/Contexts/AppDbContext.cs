using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SocialE.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Event>().ToTable("Events");
        modelBuilder.Entity<Event>().HasKey(p=>p.Id);
        modelBuilder.Entity<Event>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Event>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Event>().Property(p => p.Description).IsRequired();
        modelBuilder.Entity<Event>().Property(p => p.Price).IsRequired();
        modelBuilder.Entity<Event>().Property(p => p.EventDate).IsRequired();
        modelBuilder.Entity<Event>().Property(p => p.StartTime).IsRequired();
        modelBuilder.Entity<Event>().Property(p => p.EndTime).IsRequired();
        //Añadir relaciones
        
        //Cambiar syntax
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}