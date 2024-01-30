using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementation;

public class CompanyService : ICompanyService
{

    private readonly AppDbContext _context;

    public CompanyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetCompanyDto> Add(AddCompanyDto dto)
    {
        var company = new Company
        {
            Name = dto.Name,
            Location = dto.Location,
            EstDate = dto.EstDate,
            IsActive = dto.IsActive,
        };

        _context.Add(company);

        await _context.SaveChangesAsync();

        return await _context.companies
            .Where(b => b.Id == company.Id)
            .Select(b => new GetCompanyDto()
            {
                Id = b.Id,
                Name = b.Name,
                Location = b.Location,
            })
            .FirstAsync();

    }

    public async Task<Company> Delete(Company company)
    {
        _context.Remove(company);
        await _context.SaveChangesAsync();

        return company;
    }

    public async Task<IEnumerable<Company>> GetAll()
    {
        return await _context.companies.ToListAsync();
    }

    public async Task<Company> GetById(int id)
    {
        return await _context.companies.FindAsync(id);
    }

    public async Task<Company> GetOneById(int id)
    {
        return await _context.companies.SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Company> Update(Company company)
    {
        _context.Update(company);
        await _context.SaveChangesAsync();

        return company;
    }
}
