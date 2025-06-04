using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table("Purchase_History")]
[PrimaryKey(nameof(AvailableProgramID), nameof(CustomerID))]
public class Purchase_History
{
    [ForeignKey(nameof(Available_Program))]
    public int AvailableProgramID { get; set; }
    [ForeignKey(nameof(Customer))]
    public int CustomerID { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int? Rating { get; set; }
    
    
    public Available_Program Available_Program { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}