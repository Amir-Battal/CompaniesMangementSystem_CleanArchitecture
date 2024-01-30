using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IReportService
{
    Task<IEnumerable<Report>> GetAll();
    Task<Report> Add(Report report);
}
