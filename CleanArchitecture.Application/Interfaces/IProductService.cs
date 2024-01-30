using CleanArchitecture.Application.Dtos.Products;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<GetProductDto> Add(AddProductDto dto);
    Task<Product> Update(Product product);
    Task<Product> Delete(Product product);
}
