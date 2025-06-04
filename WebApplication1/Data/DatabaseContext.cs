using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Available_Program> Clients { get; set; }
    public DbSet<Customer> Statuses { get; set; }
    public DbSet<ProgramEntity> Products { get; set; }
    public DbSet<Purchase_History> Orders { get; set; }
    public DbSet<Washing_Machine> ProductOrders { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() { CustomerId = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123456789" },
            new Customer() { CustomerId = 2, FirstName = "Jane", LastName = "Doe", PhoneNumber = "123456789" },
            new Customer() { CustomerId = 3, FirstName = "Julie", LastName = "Doe", PhoneNumber = "123456789" },
        });
        
        modelBuilder.Entity<ProgramEntity>().HasData(new List<ProgramEntity>()
        {
            new ProgramEntity() { ProgramId = 1, Name = "Created", DurationMinutes = 10, TemperatureCelsius = 10},
            new ProgramEntity() { ProgramId = 2, Name = "Ongoing", DurationMinutes = 10, TemperatureCelsius = 10 },
            new ProgramEntity() { ProgramId = 3, Name = "Completed", DurationMinutes = 10, TemperatureCelsius = 10 },
        });
        
        modelBuilder.Entity<Washing_Machine>().HasData(new List<Washing_Machine>()
        {
            new Washing_Machine() { WashingMachineId = 1, MaxWeight = 20.20, SerialNumber = "2134" },
        });
        
        modelBuilder.Entity<Available_Program>().HasData(new List<Available_Program>()
        {
            new Available_Program() { AvailableProgramID = 1,  WashingMachineID = 1, ProgramID = 1, Price = 10.23},

        });
        
        modelBuilder.Entity<Purchase_History>().HasData(new List<Purchase_History>()
        {
            new Purchase_History() { AvailableProgramID = 1, CustomerID = 1, PurchaseDate = DateTime.Parse("2025-05-04"), Rating = 10},

        });
    }
}