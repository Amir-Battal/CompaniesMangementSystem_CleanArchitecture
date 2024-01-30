using CleanArchitecture.Application.Dtos.Branches;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IBranchService
{
    Task<IEnumerable<Branch>> GetAll();
    Task<IEnumerable<Branch>> GetPrimary();
    Task<IEnumerable<Branch>> GetSecondary();
    Task<IEnumerable<Branch>> GetByCompanyId(int companyId);
    Task<GetBranchDto> Add(AddBranchDto dto);
    Task<Branch> GetById(int id);
    Task<Branch> Update(Branch branch);
    Task<Branch> Delete(Branch branch);
}
