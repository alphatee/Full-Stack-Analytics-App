
using System.ComponentModel.DataAnnotations; // [Key]
using System.ComponentModel.DataAnnotations.Schema; // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
using TripInfo.API.Models; // CustomerDto, CustomerForCreationDto, CustomerForUpdateDto

namespace TripInfo.API.Entities;

public class Trip // (bug?)may need to change annotations and learn what other annotations are available
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

    public double Customer1Price { get; set; } = 0.0d;
    public double Customer1Tip { get; set; } = 0.0d;
    public double Customer1ServiceFee { get; set; } = 0.0d;
    public double Customer2Price { get; set; } = 0.0d;
    public double Customer2Tip { get; set; } = 0.0d;
    public double Customer2ServiceFee { get; set; } = 0.0d;
    public double Customer3Price { get; set; } = 0.0d;
    public double Customer3Tip { get; set; } = 0.0d;
    public double Customer3ServiceFee { get; set; } = 0.0d;
    public double Customer4Price { get; set; } = 0.0d;
    public double Customer4Tip { get; set; } = 0.0d;
    public double Customer4ServiceFee { get; set; } = 0.0d;
    public double Customer5Price { get; set; } = 0.0d;
    public double Customer5Tip { get; set; } = 0.0d;
    public double Customer5ServiceFee { get; set; } = 0.0d;
    public double Customer6Price { get; set; } = 0.0d;
    public double Customer6Tip { get; set; } = 0.0d;
    public double Customer6ServiceFee { get; set; } = 0.0d;
    public double Customer7Price { get; set; } = 0.0d;
    public double Customer7Tip { get; set; } = 0.0d;
    public double Customer7ServiceFee { get; set; } = 0.0d;
    public double Customer8Price { get; set; } = 0.0d;
    public double Customer8Tip { get; set; } = 0.0d;
    public double Customer8ServiceFee { get; set; } = 0.0d;
    public double Customer9Price { get; set; } = 0.0d;
    public double Customer9Tip { get; set; } = 0.0d;
    public double Customer9ServiceFee { get; set; } = 0.0d;
    public double Customer10Price { get; set; } = 0.0d;
    public double Customer10Tip { get; set; } = 0.0d;
    public double Customer10ServiceFee { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double CustomerPaymentsTotal { get; set; }
    [Required]
    [Range(0, 250)]
    public double ServiceFeeTotal { get; set; }

    public List<MetaData> MetaDataList { get; set; } = new List<MetaData>();
    public List<Customer> Customers { get; set; } = new List<Customer>();
}
