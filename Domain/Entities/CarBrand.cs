namespace Domain.Entities;

public class CarBrand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid BrandId { get; set;}
    public bool State { get; set; } = true;
}