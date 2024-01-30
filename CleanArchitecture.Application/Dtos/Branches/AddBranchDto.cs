namespace CleanArchitecture.Application.Dtos.Branches;

public class AddBranchDto
{
    public bool IsPrimary { get; set; }
    public string BranchName { get; set; }
    public string BranchLocation { get; set; }
    public int CompanyId { get; set; }
}
