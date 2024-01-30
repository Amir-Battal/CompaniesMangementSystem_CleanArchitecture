using CleanArchitecture.Application.Dtos.Branches;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementation;

public class BranchService : IBranchService
{
    private readonly AppDbContext _context;

    public BranchService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetBranchDto> Add(AddBranchDto dto)
    {
        var branch = new Branch
        {
            CompanyId = dto.CompanyId,
            IsPrimary = dto.IsPrimary,
            Name = dto.BranchName,
            Location = dto.BranchLocation,
        };

        _context.Add(branch);

        await _context.SaveChangesAsync();

        return await _context.branches
            .Where(b => b.Id == branch.Id)
            .Select(b => new GetBranchDto()
            {
                Id = b.Id,
                Location = b.Location,
                Name = b.Name
            })
            .FirstAsync();
    }

    public async Task<Branch> Delete(Branch branch)
    {
        _context.Remove(branch);
        await _context.SaveChangesAsync(); 

        return branch;
    }

    public async Task<IEnumerable<Branch>> GetAll()
    {
        return await _context.branches.ToListAsync();
    }

    public async Task<IEnumerable<Branch>> GetByCompanyId(int companyId)
    {
        return await _context.branches.Where(m => m.CompanyId == companyId).ToListAsync();
    }

    public async Task<Branch> GetById(int id)
    {
        return await _context.branches.FirstAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Branch>> GetPrimary()
    {
        return await _context.branches.Where(m => m.IsPrimary == true).ToListAsync();
    }

    public async Task<IEnumerable<Branch>> GetSecondary()
    {
        return await _context.branches.Where(m => m.IsPrimary != true).ToListAsync();
    }

    public async Task<Branch> Update(Branch branch)
    {
        _context.Update(branch);
        await _context.SaveChangesAsync();

        return branch;
    }
}
