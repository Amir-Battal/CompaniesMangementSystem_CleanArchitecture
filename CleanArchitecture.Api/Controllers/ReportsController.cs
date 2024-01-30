using CleanArchitecture.Application.Dtos.Reports;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;
    private readonly IProduceService _produceService;

    public ReportsController(IReportService reportService, IProduceService produceService)
    {
        _reportService = reportService;
        _produceService = produceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var report = await _reportService.GetAll();

        return Ok(report);
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddReportDto dto)
    {

        var report = new Report()
        {
            from = dto.from,
            to = dto.to,
            companyId = dto.companyId,
            branchId = dto.branchId,
        };

        report.produces = new List<Produce>();


        var produces = await _produceService.GetAll();

        var filteredProduces = produces.Where(c => c.CreatedDate >= dto.from && c.CreatedDate <= dto.to).ToList();

        report.produces.AddRange(filteredProduces);



        await _reportService.Add(report);

        return Ok(report);
    }
}
