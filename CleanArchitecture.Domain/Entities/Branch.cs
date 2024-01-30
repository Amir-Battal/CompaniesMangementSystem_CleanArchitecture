namespace CleanArchitecture.Domain.Entities;

public class Branch
{
    public int Id { get; set; }
    public bool IsPrimary { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }


    public int CompanyId { get; set; }
    public Company Company { get; set; }


    public int? MainBranchId { get; set; }
    public Branch? MainBranch { get; set; }

    public ICollection<Branch> SecondaryBranches { get; set; } = new List<Branch>();
}
