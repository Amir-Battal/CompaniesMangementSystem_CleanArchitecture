using CleanArchitecture.Application.Dtos.Products;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementation;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetProductDto> Add(AddProductDto dto)
    {
        var product = new Product
        {
            ProductName = dto.ProductName,
            ProductType = dto.ProductType,
        };

        _context.Add(product);

        await _context.SaveChangesAsync();

        return await _context.products
            .Where(b => b.Id == product.Id)
            .Select(b => new GetProductDto()
            {
                Id = b.Id,
                ProductName = b.ProductName,
                ProductType = b.ProductType,
            })
            .FirstAsync(); 
    }

    public async Task<Product> Delete(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.products.FindAsync(id);
    }

    public async Task<Product> Update(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }
}
