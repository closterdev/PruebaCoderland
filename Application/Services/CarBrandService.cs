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
        BrandListOut output = new();

        try
        {
            IEnumerable<CarBrand>? brandList = await _carBrandRepository.GetAllBrandsAsync();

            if (brandList.Any())
            {
                output.Message = "No existen registros actualmente.";
                output.Result = Result.NoRecords;
            }
            else
            {
                output.Message = "Lista generada correctamente.";
                output.Result = Result.Success;
                output.BrandList = brandList;
            }
        }
        catch (System.Exception ex)
        {
            output.Message = $"Ha ocurrido un error. {ex.Message}";
            output.Result = Result.Error;
        }

        return output;
    }
}