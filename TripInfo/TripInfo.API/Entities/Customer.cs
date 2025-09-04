using System.ComponentModel.DataAnnotations; // [Key]
using System.ComponentModel.DataAnnotations.Schema; // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

namespace TripInfo.API.Entities;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double CustomerPrice { get; set; } = 0.0d;
    public double CustomerTip { get; set; } = 0.0d;
    public double CustomerServiceFee { get; set; } = 0.0d;
    [MaxLength(200)]
    public string? Description { get; set; } = null;

    [ForeignKey("TripId")]
    public Trip? Trip { get; set; } // Navigation property
    public int TripId { get; set; } // Foreign key
}
