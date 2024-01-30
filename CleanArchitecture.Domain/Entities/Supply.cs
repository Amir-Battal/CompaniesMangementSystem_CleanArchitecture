using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class Supply
{
    public int BranchId { get; set; }
    public int ProductId { get; set; }
    public int SProductQuantity { get; set; }
    public DateTime SuppliedDate { get; set; }
    
    public int fromBranch { get; set; }

}
