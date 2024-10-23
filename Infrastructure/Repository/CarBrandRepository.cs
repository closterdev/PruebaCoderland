using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CarBrandRepository : ICarBrandRepository
{
    private readonly ApiContext _context;

    public CarBrandRepository(ApiContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<CarBrand>> GetAllBrandsAsync()
    {
        return await _context.CarBrand.ToListAsync();
    }
}