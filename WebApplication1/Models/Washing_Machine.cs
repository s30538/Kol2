using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table("Washing_Machine")]
public class Washing_Machine
{
    [Key]
    public int WashingMachineId { get; set; }
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public double MaxWeight { get; set; }

    [MaxLength(100)] public string SerialNumber { get; set; } = null!;
    public ICollection<Available_Program> Available_Program { get; set; } = null!;
}