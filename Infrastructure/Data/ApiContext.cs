using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<CarBrand> CarBrand { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasNoKey();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}