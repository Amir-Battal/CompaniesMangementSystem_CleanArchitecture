using CleanArchitecture.Application.Dtos.Branches;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BranchesController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchesController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var branches = await _branchService.GetAll();

        return Ok(branches);
    }


    [HttpGet("GetPrimaryBranch")]
    public async Task<IActionResult> GetPrimaryBranch()
    {
        var branches = await _branchService.GetPrimary();

        return Ok(branches);
    }


    [HttpGet("GetSecondaryBranch")]
    public async Task<IActionResult> GetSecondaryBranch()
    {
        var branches = await _branchService.GetSecondary();

        return Ok(branches);
    }


    [HttpGet("GetByComapnyId")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        var branches = await _branchService.GetByCompanyId(companyId);
        return Ok(branches);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddBranchDto dto)
        => new JsonResult(await _branchService.Add(dto));


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddBranchDto dto)
    {
        var branch = await _branchService.GetById(id);

        if (branch == null)
            return NotFound($"No branch was found with ID: {id}");

        branch.IsPrimary = dto.IsPrimary;
        branch.Name = dto.BranchName;
        branch.Location = dto.BranchLocation;
        branch.CompanyId = dto.CompanyId;

        await _branchService.Update(branch);

        return Ok(branch);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var branch = await _branchService.GetById(id);

        if (branch == null)
            return NotFound($"No branch was found with ID: {id}");

        await _branchService.Delete(branch);

        return Ok(branch);
    }
}
