namespace CleanArchitecture.Application.Dtos.Produces;

public class AddProduceDto
{
    public int BranchId { get; set; }

    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public DateTime CreatedDate { get; set; }
}
