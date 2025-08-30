using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/catalog")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;
    public CatalogController(IProductRepository productRepository)
    {
        this._repository = productRepository;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _repository.GetProduct(id);
        if (product is null)
            return NotFound("Produto não encontrado");
        return Ok(product);
    }

    [HttpGet("category")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromQuery] string categoryName)
    {
        if (categoryName is null)
        {
            return BadRequest("Categoria invalida");
        }
        var products = await _repository.GetProductsByCategory(categoryName);
        return Ok(products);
    }


    [HttpGet("name")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByName([FromQuery] string productName)
    {
        if (productName is null)
        {
            return BadRequest("Nome invalida");
        }
        var products = await _repository.GetProductsByName(productName);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        if (product is null)
            return BadRequest("Produto Invalido");

        await _repository.CreateProduct(product);
        return CreatedAtRoute("CreateProduct", new { id = product.Id }, product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (product is null)
            return BadRequest("Produto invalido para atualizar");

        return Ok(await _repository.UpdateProduct(product));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        return Ok(await _repository.DeleteProduct(id));
    }
    
    
}