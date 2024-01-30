namespace CleanArchitecture.Domain.Entities;

public class Produce
{
    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int ProductQuantity { get; set; }
    public DateTime CreatedDate { get; set; }
}
