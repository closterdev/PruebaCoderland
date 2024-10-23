using Domain.Entities;
using Shared.Common;

namespace Application.Dtos;

public class BrandListOut : BaseOut
{
    public IEnumerable<CarBrand>? BrandList { get; set; }
}