using CleanArchitecture.Application.Dtos.Supplies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SuppliesController : ControllerBase
{
    private readonly ISupplyService _supplyService;
    private readonly IBranchService _branchService;

    public SuppliesController(ISupplyService supplyService, IBranchService branchService)
    {
        _supplyService = supplyService;
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var supply = await _supplyService.GetAll();

        return Ok(supply);
    }



    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddSupplyDto dto)
    {
        var MainBranch = await _branchService.GetById(dto.BranchId);
        if (MainBranch.IsPrimary == true)
        {
            return BadRequest("This is Main Branch");
        }
        return new JsonResult(await _supplyService.Add(dto));
    }




    [HttpPut("{BranchId, ProductId}")]
    public async Task<IActionResult> UpdateAsync(int BranchId, int ProductId, [FromForm] AddSupplyDto dto)
    {
        var supply = await _supplyService.GetSuppliesByIDs(BranchId, ProductId);

        if (supply == null)
            return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

        supply.BranchId = dto.BranchId;
        supply.ProductId = dto.ProductId;
        supply.SProductQuantity = dto.SProductQuantity;
        supply.SuppliedDate = dto.SuppliedDate;

        var MainBranch = await _branchService.GetById(supply.BranchId);
        if (MainBranch.IsPrimary == true)
        {
            return BadRequest("This is Main Branch");
        }

        await _supplyService.Update(supply);

        return Ok(supply);
    }



    [HttpDelete("{BranchId, ProductId}")]
    public async Task<IActionResult> DeleteAsync(int BranchId, int ProductId)
    {
        var supply = await _supplyService.GetSuppliesByIDs(BranchId, ProductId);

        if (supply == null)
            return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

        var MainBranch = await _branchService.GetById(supply.BranchId);
        if (MainBranch.IsPrimary == true)
        {
            return BadRequest("This is Main Branch");
        }

        await _supplyService.Delete(supply);

        return Ok(supply);

    }
}
