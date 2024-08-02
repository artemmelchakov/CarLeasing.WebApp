using CarLeasing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.Data;

/// <summary>
/// Общий контекст данных для приложения CarLeasing.
/// </summary>
public class CarLeasingContext : DbContext
{
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<Provider> Providers { get; set; }

    public CarLeasingContext(DbContextOptions<CarLeasingContext> options) : base(options)
    {
        if (Database.EnsureCreated())
        {
            FillDatabase();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasIndex(e => e.ProviderId);
            entity.HasIndex(e => e.RegistrationDate);
            entity.HasOne(e => e.Provider).WithMany(e => e.Offers).HasForeignKey(e => e.ProviderId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Provider>(entity => 
        {
            entity.HasIndex(e => e.CreationDate);
        });
    }

    /// <summary>
    /// Заполнить БД начальными данными.
    /// </summary>
    private void FillDatabase()
    {
        try
        {
            var providers = new Provider[]
            {
                new() { Name = "АЛизинг", CreationDate = DateTime.UtcNow },
                new() { Name = "БЛизинг", CreationDate = DateTime.UtcNow },
                new() { Name = "ВЛизинг", CreationDate = DateTime.UtcNow },
                new() { Name = "ГЛизинг", CreationDate = DateTime.UtcNow },
                new() { Name = "ДЛизинг", CreationDate = DateTime.UtcNow }
            };
            var offers = new Offer[]
            {
            new() { Brand = "Ауди", Model = "Модель 1", Provider = providers[0], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Ауди", Model = "Модель 2", Provider = providers[0], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Рено", Model = "Модель 3", Provider = providers[0], RegistrationDate = DateTime.UtcNow },

            new() { Brand = "Рено", Model = "Модель 4", Provider = providers[1], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Рено", Model = "Модель 5", Provider = providers[1], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Рено", Model = "Модель 1", Provider = providers[1], RegistrationDate = DateTime.UtcNow },

            new() { Brand = "Камаз", Model = "Модель 3", Provider = providers[2], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Камаз", Model = "Модель 4", Provider = providers[2], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Камаз", Model = "Модель 5", Provider = providers[2], RegistrationDate = DateTime.UtcNow },

            new() { Brand = "Камаз", Model = "Модель 3", Provider = providers[3], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Фиат", Model = "Модель 41", Provider = providers[3], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Фиат", Model = "Модель 51", Provider = providers[3], RegistrationDate = DateTime.UtcNow },

            new() { Brand = "Фиат", Model = "Модель 61", Provider = providers[4], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Ауди", Model = "Модель 911", Provider = providers[4], RegistrationDate = DateTime.UtcNow },
            new() { Brand = "Ауди", Model = "Модель 91", Provider = providers[4], RegistrationDate = DateTime.UtcNow }
            };

            Providers.AddRange(providers);
            Offers.AddRange(offers);

            SaveChanges();
        }
        catch (Exception)
        {
            Database.EnsureDeleted();
            throw;
        }
    }
}
