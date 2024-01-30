using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAll();
    Task<Company> GetById(int id);
    Task<Company> GetOneById(int id);
    Task<GetCompanyDto> Add(AddCompanyDto dto);
    Task<Company> Update(Company company);
    Task<Company> Delete(Company company);
}
