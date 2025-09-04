using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel.DataAnnotations; 

namespace TripInfo.API.Entities;

public class MetaData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string StoreName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
    [Required]
    [MaxLength(100)]
    public string Street { get; set; }
    [Required]
    [MaxLength(100)]
    public string City { get; set; }
    [Required]
    [MaxLength(100)]
    public string State { get; set; }
    [Required]
    [MaxLength(10)]
    public string Zip { get; set; }
    [Required]
    [StringLength(3, MinimumLength = 2)]
    public string Country { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
    [Required]
    public double Distance { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public int PointsEarned { get; set; }

    [Required]
    public double Fare { get; set; }
    public double Promotion { get; set; } = 0.0d;
    public double Boost { get; set; } = 0.0d;
    public double Tip { get; set; } = 0.0d;
    [Required]
    public double YourEarnings { get; set; }

    [ForeignKey("TripId")]
    public Trip? Trip { get; set; } // Navigation property
    public int TripId { get; set; }  // Foreign key
}
