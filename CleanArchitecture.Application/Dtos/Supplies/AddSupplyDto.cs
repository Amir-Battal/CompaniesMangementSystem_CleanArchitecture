namespace CleanArchitecture.Application.Dtos.Supplies;

public class AddSupplyDto
{
    public int BranchId { get; set; }

    public int ProductId { get; set; }

    public int SProductQuantity { get; set; }

    public DateTime SuppliedDate { get; set; }

}
