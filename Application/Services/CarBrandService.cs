using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Ports;
using Shared.Common;

namespace Application.Services;

public class CarBrandService : ICarBrandService
{
    private readonly ICarBrandRepository _carBrandRepository;

    public CarBrandService(ICarBrandRepository carBrandRepository)
    {
        _carBrandRepository = carBrandRepository;
    }
    public async Task<BrandListOut> GetBrandsAsync()
    {
        try
        {
            IEnumerable<CarBrand>? brandList = await _carBrandRepository.GetAllBrandsAsync();

            return brandList.Any()
                ? new BrandListOut { Message = "No existen registros actualmente.", Result = Result.NoRecords }
                : new BrandListOut { Message = "Lista generada correctamente.", Result = Result.Success, BrandList = brandList };
        }
        catch (System.Exception ex)
        {
            return new BrandListOut { Message = $"Ha ocurrido un error. {ex.Message}", Result = Result.Error };
        }
    }
}