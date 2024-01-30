using CleanArchitecture.Application.Dtos.Branches;
using CleanArchitecture.Application.Dtos.Produces;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProducesController : ControllerBase
{
    private readonly IProduceService _produceService;
    private readonly IBranchService _branchService;

    public ProducesController(IProduceService produceService, IBranchService branchService)
    {
        _produceService = produceService;
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var produce = await _produceService.GetAll();

        return Ok(produce);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddProduceDto dto)
    {
        var MainBranch = await _branchService.GetById(dto.BranchId);
        if (MainBranch.IsPrimary != true)
        {
            return BadRequest("This is Not Main Branch");
        }
        return new JsonResult(await _produceService.Add(dto));
    }



    [HttpPut("{BranchId, ProductId}")]
    public async Task<IActionResult> UpdateAsync(int BranchId, int ProductId, [FromForm] AddProduceDto dto)
    {
        var produce = await _produceService.GetProducesByIDs(BranchId, ProductId);

        if (produce == null)
            return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

        produce.BranchId = dto.BranchId;
        produce.ProductId = dto.ProductId;
        produce.ProductQuantity = dto.ProductQuantity;
        produce.CreatedDate = dto.CreatedDate;

        var MainBranch = await _branchService.GetById(dto.BranchId);
        if (!MainBranch.IsPrimary == true)
        {
            return BadRequest("This is not Main Branch");
        }

        await _produceService.Update(produce);

        return Ok(produce);
    }


    [HttpDelete("{BranchId, ProductId}")]
    public async Task<IActionResult> DeleteAsync(int BranchId, int ProductId)
    {
        var produce = await _produceService.GetProducesByIDs(BranchId, ProductId);

        if (produce == null)
            return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

        var MainBranch = await _branchService.GetById(BranchId);
        if (!MainBranch.IsPrimary == true)
        {
            return BadRequest("This is not Main Branch");
        }

        await _produceService.Delete(produce);

        return Ok(produce);

    }
}
