using CleanArchitecture.Application.Dtos.Supplies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementation;

public class SupplyService : ISupplyService
{
    private readonly AppDbContext _context;
    private readonly IProduceService _produceService;
    private readonly IBranchService _branchService;

    public SupplyService(AppDbContext context, IProduceService produceService)
    {
        _context = context;
        _produceService = produceService;
    }

    public async Task<GetSupplyDto> Add(AddSupplyDto dto)
    {
        var supply = new Supply()
        {
            BranchId = dto.BranchId,
            ProductId = dto.ProductId,
            SProductQuantity = dto.SProductQuantity,
            SuppliedDate = dto.SuppliedDate,
        };

        var produces = await _produceService.GetAll();
        foreach (var produce in produces)
        {
            if (produce.ProductId == dto.ProductId)
            {
                supply.fromBranch = produce.BranchId;
            }
        }


        _context.Add(supply);

        await _context.SaveChangesAsync();

        return await _context.supplys
            .Where(b => b.BranchId == supply.BranchId && b.ProductId == supply.ProductId)
            .Select(b => new GetSupplyDto()
            {
                BranchId = b.BranchId,
                ProductId = b.ProductId,
                SProductQuantity = b.SProductQuantity,
                SuppliedDate = b.SuppliedDate,
                fromBranch = b.fromBranch
            })
            .FirstAsync();

    }


    public async Task<Supply> Delete(Supply supply)
    {
        _context.Remove(supply);
        await _context.SaveChangesAsync();

        return supply;
    }

    public async Task<IEnumerable<Supply>> GetAll()
    {
        return await _context.supplys.ToListAsync();
    }

    public async Task<Supply> GetSuppliesByIDs(int branchId, int productId)
    {
        return await _context.supplys.FindAsync(branchId, productId);
    }

    public async Task<Supply> Update(Supply supply)
    {
        _context.Update(supply);
        await _context.SaveChangesAsync();

        return supply;
    }
}
