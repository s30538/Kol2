using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table("Available_Program")]

public class Available_Program
{
    [Key]
    public int AvailableProgramID { get; set; }
    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineID { get; set; }
    [ForeignKey(nameof(ProgramEntity))]
    public int ProgramID { get; set; }
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public double Price { get; set; }
    
    public Washing_Machine WashingMachine { get; set; } = null!;
    public ProgramEntity ProgramEntity { get; set; } = null!;
    
    public ICollection<Purchase_History> PurchaseHistoryes { get; set; } = null!;
}