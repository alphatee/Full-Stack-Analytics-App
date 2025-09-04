using System.ComponentModel.DataAnnotations; // [Required]

namespace TripInfo.API.Models;

// Taken from "FlattenedFileDataManipulator.cs" 
public class CustomerForCreationDto
{
    [Required]
    [Range(0, 250)]
    public double CustomerPrice { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double CustomerTip { get; set; } = 0.0d;

    [Required]
    [Range(0, 250)]
    public double CustomerServiceFee { get; set; } = 0.0d;

    [MaxLength(200)]
    public string? Description { get; set; } = null;
}
