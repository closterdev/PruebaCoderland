using Application.Dtos;

namespace Application.Interfaces;

public interface ICarBrandService
{
    Task<BrandListOut> GetBrandsAsync();
}