namespace CleanArchitecture.Application.Dtos.Reports;

public class AddReportDto
{
    public int companyId { get; set; }

    public int branchId { get; set; }

    public DateTime from { get; set; }

    public DateTime to { get; set; }
}
