using CleanArchitecture.Application.Dtos.Produces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IProduceService
{
    Task<IEnumerable<Produce>> GetAll();
    Task<GetProduceDto> Add(AddProduceDto dto);
    Task<Produce> Update(Produce produce);
    Task<Produce> GetProducesByIDs(int branchId, int productId);
    Task<Produce> Delete(Produce produce); 
}
