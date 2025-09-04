using System.ComponentModel.DataAnnotations;

namespace TripInfo.API.Models;

public class MetaDataDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "You should provide a Store Name value.")]
    [MaxLength(200)]
    public string StoreName { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string State { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Zip { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Country { get; set; } = string.Empty;

    [Required]
    public TimeSpan Duration { get; set; }

    [Required]
    [Range(0, 250)]
    public double Distance { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    [Range(0, 250)]
    public int PointsEarned { get; set; }

    [Required]
    [Range(0, 250)]
    public double Fare { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Promotion { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Boost { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double YourEarnings { get; set; } = 0.0d;
}
