namespace CleanArchitecture.Application.Dtos.Supplies;

public class GetSupplyDto
{
    public int BranchId { get; set; }

    public int ProductId { get; set; }

    public int SProductQuantity { get; set; }

    public DateTime SuppliedDate { get; set; }

    public int fromBranch { get; set; }

}
