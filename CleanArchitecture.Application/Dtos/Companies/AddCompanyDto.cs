namespace CleanArchitecture.Application.Dtos.Companies;

public class AddCompanyDto
{
    public string Name { get; set; }

    public string Location { get; set; }

    public DateTime EstDate { get; set; }

    public bool IsActive { get; set; }
}
