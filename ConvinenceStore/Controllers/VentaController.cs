
using ConvinenceStore.Business.Interface;
using ConvinenceStore.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using NameSpace.Models.DTO;

namespace ConvinenceStore.Controllers;
[ApiController]
[Route("[Controller]")]
public class VentaController:ControllerBase{

    private readonly ISale _saleProvider;
    public VentaController(ISale saleProvider)
    {
        _saleProvider = saleProvider;
    }

    [HttpGet("obtenerVentas")]
    public IActionResult getVentas()
    {
        try
        {
            var result = _saleProvider.getVentas();
            return Ok(result.Result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("registrar")]
    public IActionResult registrarVenta([FromBody] SaleDataDTO sale)
    {
        if (ModelState.IsValid)
        {
            var result = _saleProvider.putVenta(sale);
            return StatusCode(result.Result);
        }
        return BadRequest();
    }

}