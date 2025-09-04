using TripInfo.API.Entities; 

namespace TripInfo.API.Models;

// Taken from "FlattenedFileDataManipulator.cs" 
public class CustomerDto 
{
    public int Id { get; set; }
    public double CustomerPrice { get; set; } = 0.0d;
    public double CustomerTip { get; set; } = 0.0d;
    public double CustomerServiceFee { get; set; } = 0.0d;
    public string? Description { get; set; } = null;
}
