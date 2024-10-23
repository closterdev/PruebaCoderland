using Domain.Entities;

namespace Domain.Ports;

public interface ICarBrandRepository
{
    Task<IEnumerable<CarBrand>> GetAllBrandsAsync();
}