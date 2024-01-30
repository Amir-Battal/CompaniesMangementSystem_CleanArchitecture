using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()

    {
        var companies = await _companyService.GetAll();

        return Ok(companies);
    }




    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var company = await _companyService.GetOneById(id);

        if (company == null)
            return NotFound();

        return Ok(company);
    }




    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddCompanyDto dto)
        => new JsonResult(await _companyService.Add(dto));



    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddCompanyDto dto)
    {
        var company = await _companyService.GetById(id);

        if (company == null)
            return NotFound($"No comapny was found with ID: {id}");

        company.Name = dto.Name;
        company.Location = dto.Location;
        company.EstDate = dto.EstDate;
        company.IsActive = dto.IsActive;

        await _companyService.Update(company);

        return Ok(company);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var company = await _companyService.GetById(id);

        if (company == null)
            return NotFound($"No comapny was found with ID: {id}");

        await _companyService.Delete(company);

        return Ok(company);

    }
}
