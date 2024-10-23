using Application.Services;
using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shared.Common;

namespace UnitTest;

public class CarBrandServiceTest
{
    private readonly CarBrandService _brandService;
    private readonly Mock<ICarBrandRepository> _brandRepositoryMock;

    public CarBrandServiceTest()
    {
        _brandRepositoryMock = new Mock<ICarBrandRepository>();
        _brandService = new CarBrandService(_brandRepositoryMock.Object);
    }

    private ApiContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "dbautos")
            .Options;

        var context = new ApiContext(options);

        // Prepopulate the in-memory database with test data
        context.CarBrand.AddRange(
            new CarBrand { Id = 1, Name = "Toyota" },
            new CarBrand { Id = 2, Name = "Ford" },
            new CarBrand { Id = 3, Name = "BMW" }
        );
        context.SaveChanges();

        return context;
    }

    [Fact]
    public async Task GetBrandAsync_Success()
    {
        // Arrange
        var dbContext = GetInMemoryContext();

        // Act
        var result = await _brandService.GetBrandsAsync();

        // Assert
        var actionResult = Assert.IsType<IEnumerable<CarBrand>>(result);
        var returnValue = Assert.IsType<List<CarBrand>>(actionResult);

        Assert.Equal(3, returnValue.Count);
        Assert.Contains(returnValue, cb => cb.Name == "Toyota");
        Assert.Contains(returnValue, cb => cb.Name == "Ford");
        Assert.Contains(returnValue, cb => cb.Name == "BMW");
    }

    [Fact]
    public async Task GetBrandAsync_NoRecords()
    {
        // Arrange
        _brandRepositoryMock.Setup(repo => repo.GetAllBrandsAsync())
                               .ReturnsAsync(new List<CarBrand>());

        // Act
        var result = await _brandService.GetBrandsAsync();

        // Assert
        Assert.Equal(Result.NoRecords, result.Result);
        Assert.Equal("No existen registros actualmente.", result.Message);
        Assert.Null(result.BrandList);
    }
}