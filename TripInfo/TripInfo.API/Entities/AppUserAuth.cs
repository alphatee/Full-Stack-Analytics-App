namespace TripInfo.API.Entities;

public class AppUserAuth : UserAuthBase
{
    public AppUserAuth() : base() 
    {
        CanAccessProducts = false;
        CanAccessCategories = false;
        CanAccessLogs = false;
        CanAccessSettings = false;
        CanAccessTravelDetails = false;
        CanAddProduct = false;
        CanEditProduct = false;
        CanDeleteProduct = false;
    }

    public bool CanAccessProducts { get; set; }
    public bool CanAccessCategories { get; set; }
    public bool CanAccessLogs { get; set; }
    public bool CanAccessSettings { get; set; }
    public bool CanAccessTravelDetails { get; set; }
    public bool CanAddProduct { get; set; }
    public bool CanEditProduct { get; set; }
    public bool CanDeleteProduct { get; set; }
}
