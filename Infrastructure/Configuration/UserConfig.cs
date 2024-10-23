using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);
        builder.HasData(new List<User>()
        {
            new () {Username = "admin", Password = "admin"},
            new () {Username = "developer", Password = "developer"}
        });
        throw new NotImplementedException();
    }
}