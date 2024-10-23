using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaCoderlandBack.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarBrandController : ControllerBase
{
    private readonly ICarBrandService _brand;

    /// <summary>
    /// Constructor method
    /// </summary>
    /// <param name="brand"></param>
    public CarBrandController(ICarBrandService brand)
    {
        _brand = brand;
    }
    /// <summary>
    /// Get all brand items
    /// </summary>
    /// <returns>Array of brand items</returns>
    /// <remarks>GET: api/Coderland</remarks>
    /// <response code="200"><strong>Success</strong><br/>
    /// <ul>
    ///     <li><b>message:</b> Descripcion de la solicitud realizada.</li>
    ///     <li><b>result:</b> Indice de resultados.
    ///         <ul>
    ///             <li>Success => 0</li>
    ///             <li>Error => 1</li>
    ///             <li>NoRecords => 2</li>
    ///             <li>IsNotActive => 3</li>
    ///             <li>InvalidPassword => 4</li>
    ///         </ul>
    ///     </li>
    ///     <li><b>resultAsString:</b> Descripcion del valor de <i>result.</i></li>
    /// </ul>
    /// </response>
    /// <response code="400"><strong>BadRequest</strong></response>
    /// <response code="401"><strong>UnAuthorized</strong></response>
    /// <response code="500"><strong>InternalError</strong></response>
    [ProducesResponseType(typeof(BrandListOut), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            BrandListOut output = await _brand.GetBrandsAsync();
            return Ok(output);
        }
        catch (Exception ex)
        {
            return Problem($"Error interno al consultar las marcas de autos: {ex.Message}", statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}