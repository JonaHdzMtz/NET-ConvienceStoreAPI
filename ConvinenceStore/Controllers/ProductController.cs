


using ConvinenceStore.Business.Interface;
using ConvinenceStore.Models.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;



namespace ConvinenceStore.Controllers;
[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    private readonly IProduct _productProvider;
    public ProductController(IProduct productProvider)
    {
        _productProvider = productProvider;
    }

    [HttpGet("obtenerProductos")]
    public IActionResult getProducts()
    {
        try
        {
            var result = _productProvider.getProductsAsync();
            return Ok(result.Result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("registrarProducto")]
    public IActionResult registrarProducto([FromBody] ProductDTO product)
    {
        if (ModelState.IsValid)
        {
            var result = _productProvider.createProduct(product);
            // Console.WriteLine(product);
            return StatusCode(result.Result);
        }
        return BadRequest();
       
    }

    
}