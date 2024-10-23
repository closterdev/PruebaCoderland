using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public class CarBrandConfig : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.ToTable(nameof(CarBrand));
        builder.HasKey(x => x.Id);
        builder.Property(p => p.State)
            .HasDefaultValue(true);
        builder.HasData(new List<CarBrand>()
        {
            new () {Name = "Chevrolet", Description = "Es un fabricante de automóviles y camiones con sede en Detroit, Míchigan, Estados Unidos, como una división de General Motors.", BrandId = Guid.NewGuid()},
            new () {Name = "Mazda", Description = "Es una firma de origen japonés fundada en 1920 y con sede en la ciudad de Hiroshima.", BrandId = Guid.NewGuid()},
            new () {Name = "Ford", Description = "Es una empresa multinacional fabricante de automóviles de origen estadounidense.", BrandId = Guid.NewGuid()}
        });
    }
}