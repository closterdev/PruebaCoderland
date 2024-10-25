using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(eb =>
        {
            eb.HasNoKey();
            eb.ToView("UserView");
        });
        modelBuilder.Entity<User>().ToSqlQuery(@"INSERT INTO User (Username, Password) 
                                                    VALUES ('admin', 'admin'), ('developer', 'developer')");
        modelBuilder.Entity<CarBrand>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}