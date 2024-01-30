using CleanArchitecture.Application.Dtos.Products;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _productService.GetAll();

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddProductDto dto)
        => new JsonResult(await _productService.Add(dto));


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddProductDto dto)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound($"No product was found with ID: {id}");

        product.ProductName = dto.ProductName;
        product.ProductType = dto.ProductType;

        await _productService.Update(product);

        return Ok(product);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound($"No product was found with ID: {id}");

        await _productService.Delete(product);

        return Ok(product);

    }
}
