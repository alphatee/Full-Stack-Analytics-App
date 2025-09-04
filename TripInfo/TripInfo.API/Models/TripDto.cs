using System.ComponentModel.DataAnnotations; // [Required]

namespace TripInfo.API.Models;

public class TripDto
{
    /// <summary>
    /// Gets or sets the trip identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the store name.
    /// </summary>
    [Required(ErrorMessage = "You should provide a Store Name value.")]
    [MaxLength(200)]
    public string StoreName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
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

    [Required]
    [Range(0, 250)]
    public double Customer1Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer1Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer1ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer2Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer2Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer2ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer3Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer3Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer3ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer4Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer4Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer4ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer5Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer5Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer5ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer6Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer6Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer6ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer7Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer7Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer7ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer8Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer8Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer8ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer9Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer9Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer9ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer10Price { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer10Tip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double Customer10ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double CustomerPaymentsTotal { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double ServiceFeeTotal { get; set; } = 0.0d;

    public int NumberOfCustomers
    {
        get
        {
            return Customers.Count;
        }
    }

    public ICollection<CustomerDto> Customers { get; set; }
        = new List<CustomerDto>();
}
