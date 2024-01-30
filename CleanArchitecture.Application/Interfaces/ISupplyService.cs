using CleanArchitecture.Application.Dtos.Supplies;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface ISupplyService
{
    Task<IEnumerable<Supply>> GetAll();
    Task<GetSupplyDto> Add(AddSupplyDto dto);
    Task<Supply> Update(Supply supply);
    Task<Supply> GetSuppliesByIDs(int branchId, int productId);
    Task<Supply> Delete(Supply supply);
}
