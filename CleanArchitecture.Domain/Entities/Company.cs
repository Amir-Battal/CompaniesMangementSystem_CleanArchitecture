namespace CleanArchitecture.Domain.Entities;

public class Company
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public DateTime EstDate { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
