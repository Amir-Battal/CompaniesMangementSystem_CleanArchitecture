using CleanArchitecture.Application.Dtos.Produces;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementation;

public class ProduceService : IProduceService
{
    private readonly AppDbContext _context;

    public ProduceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetProduceDto> Add(AddProduceDto dto)
    {
        var produce = new Produce()
        {
            BranchId = dto.BranchId,
            ProductId = dto.ProductId,
            CreatedDate = dto.CreatedDate,
            ProductQuantity = dto.ProductQuantity,
        };

        _context.Add(produce);

        await _context.SaveChangesAsync();

        return await _context.produces
            .Where(b => b.BranchId == dto.BranchId && b.ProductId == dto.ProductId)
            .Select(b => new GetProduceDto()
            {
                BranchId = b.BranchId,
                ProductId = b.ProductId,
                ProductQuantity = b.ProductQuantity,
                CreatedDate = b.CreatedDate,
            })
            .FirstAsync();
    }

    public async Task<Produce> Delete(Produce produce)
    {
        _context.Remove(produce);
        await _context.SaveChangesAsync();

        return produce;
    }

    public async Task<IEnumerable<Produce>> GetAll()
    {
        return await _context.produces
            .Include(m => m.Branch)
            .Include(m => m.Product)
            .ToListAsync();
    }

    public async Task<Produce> GetProducesByIDs(int branchId, int productId)
    {
        return await _context.produces.FindAsync(branchId, productId);
    }

    public async Task<Produce> Update(Produce produce)
    {
        _context.Update(produce);
        await _context.SaveChangesAsync();

        return produce;
    }
}
