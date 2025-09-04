using Microsoft.EntityFrameworkCore; // TripInfoContext inherits from DbContext
using TripInfo.API.Entities; // TripInfoContext has DbSet<Trip> Trips and DbSet<Customer> Customers and DbSet<Customer>

namespace TripInfo.API.DbContexts;

public class TripInfoContext : DbContext
{
    public DbSet<Trip> Trips { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<MetaData> MetaData { get; set; } = null!;
    public DbSet<UserBase> Users { get; set; } = null!;
    public DbSet<UserClaim> Claims { get; set; } = null!;

    public TripInfoContext(DbContextOptions<TripInfoContext> options) 
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<MetaData>()
            .HasData(
            new MetaData()
            {
                Id = -1,
                StoreName = "Coco Ichibanya Curry House (San Diego) ",
                Address = "Pacific Hwy, San Diego, CA 92101-1128, US",
                Street = "Pacific Hwy",
                City = "San Diego",
                State = "CA",
                Zip = "92101-1128",
                Country = "US",
                Duration = new TimeSpan(0, 33, 21),
                Distance = 12.6,
                DateTime = DateTime.Parse("07/03/2023 11:23:00"),
                PointsEarned = 3,
                Fare = 8.52,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 6.56d,
                YourEarnings = 15.08d,
                TripId = -1
            },
            new MetaData()
            {
                Id = -2,
                StoreName = "Adam's Wine & Spirits ",
                Address = "Butternut Ln, San Diego, CA 92123, USA",
                Street = "Butternut Ln",
                City = "San Diego",
                State = "CA",
                Zip = "92123",
                Country = "USA",
                Duration = new TimeSpan(0, 21, 11),
                Distance = 7.4,
                DateTime = DateTime.Parse("07/03/2023 20:27:00"),
                PointsEarned = 6,
                Fare = 7.84,
                Promotion = 1.28d,
                Boost = 1.28d,
                Tip = 5.5d,
                YourEarnings = 14.62d,
                TripId = -2
            },
            new MetaData()
            {
                Id = -3,
                StoreName = "Mendocino Farms ",
                Address = "Convoy Ct, San Diego, CA 92111, USA",
                Street = "Convoy Ct",
                City = "San Diego",
                State = "CA",
                Zip = "92111",
                Country = "USA",
                Duration = new TimeSpan(0, 48, 49),
                Distance = 9.9,
                DateTime = DateTime.Parse("07/07/2023 11:25:00"),
                PointsEarned = 6,
                Fare = 9.85,
                Promotion = 0.24d,
                Boost = 0.24d,
                Tip = 39.91d,
                YourEarnings = 50.0d,
                TripId = -3
            },
            new MetaData()
            {
                Id = -4,
                StoreName = "Mendocino Farms ",
                Address = "Convoy Ct, San Diego, CA 92111, USA",
                Street = "Convoy Ct",
                City = "San Diego",
                State = "CA",
                Zip = "92111",
                Country = "USA",
                Duration = new TimeSpan(0, 22, 19),
                Distance = 2.9,
                DateTime = DateTime.Parse("07/08/2023 10:15:00"),
                PointsEarned = 6,
                Fare = 2.85,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 9.11d,
                YourEarnings = 11.96d,
                TripId = -4
            },
            new MetaData()
            {
                Id = -5,
                StoreName = "Mendocino Farms ",
                Address = "Convoy Ct, San Diego, CA 92111, USA",
                Street = "Convoy Ct",
                City = "San Diego",
                State = "CA",
                Zip = "92111",
                Country = "USA",
                Duration = new TimeSpan(0, 16, 49),
                Distance = 5.9,
                DateTime = DateTime.Parse("07/04/2023 09:13:00"),
                PointsEarned = 6,
                Fare = 4.25,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 10.0d,
                YourEarnings = 14.25d,
                TripId = -5
            },
            new MetaData()
            {
                Id = -6,
                StoreName = "Adam's Wine & Spirits ",
                Address = "Butternut Ln, San Diego, CA 92123, USA",
                Street = "Butternut Ln",
                City = "San Diego",
                State = "CA",
                Zip = "92123",
                Country = "USA",
                Duration = new TimeSpan(0, 9, 21),
                Distance = 1.4,
                DateTime = DateTime.Parse("07/02/2023 20:27:00"),
                PointsEarned = 3,
                Fare = 17.84,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 15.5d,
                YourEarnings = 33.34d,
                TripId = -6
            });

        modelBuilder.Entity<Trip>()
            .HasData(
            new Trip()
            {
                Id = -1,
                StoreName = "Coco Ichibanya Curry House (San Diego) ",
                Address = "Pacific Hwy, San Diego, CA 92101-1128, US",
                Street = "Pacific Hwy",
                City = "San Diego",
                State = "CA",
                Zip = "92101-1128",
                Country = "US",
                Duration = new TimeSpan(0, 33, 21),
                Distance = 12.6,
                DateTime = DateTime.Parse("07/03/2023 11:23:00"),
                PointsEarned = 3,
                Fare = 8.52,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 6.56d,
                YourEarnings = 15.08d,
                Customer1Price = 22.15d,
                Customer1Tip = 6.56d,
                Customer1ServiceFee = 13.63d,
                Customer2Price = 0.0d,
                Customer2Tip = 0.0d,
                Customer2ServiceFee = 0.0d,
                Customer3Price = 0.0d,
                Customer3Tip = 0.0d,
                Customer3ServiceFee = 0.0d,
                Customer4Price = 0.0d,
                Customer4Tip = 0.0d,
                Customer4ServiceFee = 0.0d,
                Customer5Price = 0.0d,
                Customer5Tip = 0.0d,
                Customer5ServiceFee = 0.0d,
                Customer6Price = 0.0d,
                Customer6Tip = 0.0d,
                Customer6ServiceFee = 0.0d,
                Customer7Price = 0.0d,
                Customer7Tip = 0.0d,
                Customer7ServiceFee = 0.0d,
                Customer8Price = 0.0d,
                Customer8Tip = 0.0d,
                Customer8ServiceFee = 0.0d,
                Customer9Price = 0.0d,
                Customer9Tip = 0.0d,
                Customer9ServiceFee = 0.0d,
                Customer10Price = 0.0d,
                Customer10Tip = 0.0d,
                Customer10ServiceFee = 0.0d,
                CustomerPaymentsTotal = 28.71d,
                ServiceFeeTotal = 13.63d
            },
            new Trip
            {
                Id = -2,
                StoreName = "Adam's Wine & Spirits ",
                Address = "Butternut Ln, San Diego, CA 92123, USA",
                Street = "Butternut Ln",
                City = "San Diego",
                State = "CA",
                Zip = "92123",
                Country = "USA",
                Duration = new TimeSpan(0, 21, 11),
                Distance = 7.4,
                DateTime = DateTime.Parse("07/03/2023 20:27:00"),
                PointsEarned = 6,
                Fare = 7.84,
                Promotion = 1.28d,
                Boost = 1.28d,
                Tip = 5.5d,
                YourEarnings = 14.62d,
                Customer1Price = 12.99d,
                Customer1Tip = 5.5d,
                Customer1ServiceFee = 3.87d,
                Customer2Price = 0.0d,
                Customer2Tip = 0.0d,
                Customer2ServiceFee = 0.0d,
                Customer3Price = 0.0d,
                Customer3Tip = 0.0d,
                Customer3ServiceFee = 0.0d,
                Customer4Price = 0.0d,
                Customer4Tip = 0.0d,
                Customer4ServiceFee = 0.0d,
                Customer5Price = 0.0d,
                Customer5Tip = 0.0d,
                Customer5ServiceFee = 0.0d,
                Customer6Price = 0.0d,
                Customer6Tip = 0.0d,
                Customer6ServiceFee = 0.0d,
                Customer7Price = 0.0d,
                Customer7Tip = 0.0d,
                Customer7ServiceFee = 0.0d,
                Customer8Price = 0.0d,
                Customer8Tip = 0.0d,
                Customer8ServiceFee = 0.0d,
                Customer9Price = 0.0d,
                Customer9Tip = 0.0d,
                Customer9ServiceFee = 0.0d,
                Customer10Price = 0.0d,
                Customer10Tip = 0.0d,
                Customer10ServiceFee = 0.0d,
                CustomerPaymentsTotal = 18.49d,
                ServiceFeeTotal = 3.87d
            },
            new Trip
            {
                Id = -3,
                StoreName = "Mendocino Farms ",
                Address = "Convoy Ct, San Diego, CA 92111, USA",
                Street = "Convoy Ct",
                City = "San Diego",
                State = "CA",
                Zip = "92111",
                Country = "USA",
                Duration = new TimeSpan(0, 48, 49),
                Distance = 9.9,
                DateTime = DateTime.Parse("07/07/2023 11:25:00"),
                PointsEarned = 6,
                Fare = 9.85,
                Promotion = 0.24d,
                Boost = 0.24d,
                Tip = 39.91d,
                YourEarnings = 50.0d,
                Customer1Price = 9.3d,
                Customer1Tip = 17.23d,
                Customer1ServiceFee = 4.38d,
                Customer2Price = 10.49d,
                Customer2Tip = 22.68d,
                Customer2ServiceFee = 5.32d,
                Customer3Price = 0.0d,
                Customer3Tip = 0.0d,
                Customer3ServiceFee = 0.0d,
                Customer4Price = 0.0d,
                Customer4Tip = 0.0d,
                Customer4ServiceFee = 0.0d,
                Customer5Price = 0.0d,
                Customer5Tip = 0.0d,
                Customer5ServiceFee = 0.0d,
                Customer6Price = 0.0d,
                Customer6Tip = 0.0d,
                Customer6ServiceFee = 0.0d,
                Customer7Price = 0.0d,
                Customer7Tip = 0.0d,
                Customer7ServiceFee = 0.0d,
                Customer8Price = 0.0d,
                Customer8Tip = 0.0d,
                Customer8ServiceFee = 0.0d,
                Customer9Price = 0.0d,
                Customer9Tip = 0.0d,
                Customer9ServiceFee = 0.0d,
                Customer10Price = 0.0d,
                Customer10Tip = 0.0d,
                Customer10ServiceFee = 0.0d,
                CustomerPaymentsTotal = 59.7d,
                ServiceFeeTotal = 9.7d
            },
            new Trip
            {
                Id = -4,
                StoreName = "Mendocino Farms ",
                Address = "Convoy Ct, San Diego, CA 92111, USA",
                Street = "Convoy Ct",
                City = "San Diego",
                State = "CA",
                Zip = "92111",
                Country = "USA",
                Duration = new TimeSpan(0, 22, 19),
                Distance = 2.9,
                DateTime = DateTime.Parse("07/08/2023 10:15:00"),
                PointsEarned = 6,
                Fare = 2.85,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 9.11d,
                YourEarnings = 11.96d,
                Customer1Price = 1.0d,
                Customer1Tip = 8.11d,
                Customer1ServiceFee = 4.38d,
                Customer2Price = 1.85d,
                Customer2Tip = 1.00d,
                Customer2ServiceFee = 5.32d,
                Customer3Price = 0.0d,
                Customer3Tip = 0.0d,
                Customer3ServiceFee = 0.0d,
                Customer4Price = 0.0d,
                Customer4Tip = 0.0d,
                Customer4ServiceFee = 0.0d,
                Customer5Price = 0.0d,
                Customer5Tip = 0.0d,
                Customer5ServiceFee = 0.0d,
                Customer6Price = 0.0d,
                Customer6Tip = 0.0d,
                Customer6ServiceFee = 0.0d,
                Customer7Price = 0.0d,
                Customer7Tip = 0.0d,
                Customer7ServiceFee = 0.0d,
                Customer8Price = 0.0d,
                Customer8Tip = 0.0d,
                Customer8ServiceFee = 0.0d,
                Customer9Price = 0.0d,
                Customer9Tip = 0.0d,
                Customer9ServiceFee = 0.0d,
                Customer10Price = 0.0d,
                Customer10Tip = 0.0d,
                Customer10ServiceFee = 0.0d,
                CustomerPaymentsTotal = 21.66d,
                ServiceFeeTotal = 9.7d
            },
            new Trip
            {
                Id = -5,
                StoreName = "Mendocino Farms ",
                Address = "Convoy Ct, San Diego, CA 92111, USA",
                Street = "Convoy Ct",
                City = "San Diego",
                State = "CA",
                Zip = "92111",
                Country = "USA",
                Duration = new TimeSpan(0, 16, 49),
                Distance = 5.9,
                DateTime = DateTime.Parse("07/04/2023 09:13:00"),
                PointsEarned = 6,
                Fare = 4.25,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 10.0d,
                YourEarnings = 14.25d,
                Customer1Price = 2.25d,
                Customer1Tip = 5.0d,
                Customer1ServiceFee = 4.38d,
                Customer2Price = 2.0d,
                Customer2Tip = 5.0d,
                Customer2ServiceFee = 5.32d,
                Customer3Price = 0.0d,
                Customer3Tip = 0.0d,
                Customer3ServiceFee = 0.0d,
                Customer4Price = 0.0d,
                Customer4Tip = 0.0d,
                Customer4ServiceFee = 0.0d,
                Customer5Price = 0.0d,
                Customer5Tip = 0.0d,
                Customer5ServiceFee = 0.0d,
                Customer6Price = 0.0d,
                Customer6Tip = 0.0d,
                Customer6ServiceFee = 0.0d,
                Customer7Price = 0.0d,
                Customer7Tip = 0.0d,
                Customer7ServiceFee = 0.0d,
                Customer8Price = 0.0d,
                Customer8Tip = 0.0d,
                Customer8ServiceFee = 0.0d,
                Customer9Price = 0.0d,
                Customer9Tip = 0.0d,
                Customer9ServiceFee = 0.0d,
                Customer10Price = 0.0d,
                Customer10Tip = 0.0d,
                Customer10ServiceFee = 0.0d,
                CustomerPaymentsTotal = 23.95d,
                ServiceFeeTotal = 9.7d
            },
            new Trip
            {
                Id = -6,
                StoreName = "Adam's Wine & Spirits ",
                Address = "Butternut Ln, San Diego, CA 92123, USA",
                Street = "Butternut Ln",
                City = "San Diego",
                State = "CA",
                Zip = "92123",
                Country = "USA",
                Duration = new TimeSpan(0, 9, 21),
                Distance = 1.4,
                DateTime = DateTime.Parse("07/02/2023 20:27:00"),
                PointsEarned = 3,
                Fare = 17.84,
                Promotion = 0.0d,
                Boost = 0.0d,
                Tip = 15.5d,
                YourEarnings = 33.34d,
                Customer1Price = 17.84d,
                Customer1Tip = 15.5d,
                Customer1ServiceFee = 3.87d,
                Customer2Price = 0.0d,
                Customer2Tip = 0.0d,
                Customer2ServiceFee = 0.0d,
                Customer3Price = 0.0d,
                Customer3Tip = 0.0d,
                Customer3ServiceFee = 0.0d,
                Customer4Price = 0.0d,
                Customer4Tip = 0.0d,
                Customer4ServiceFee = 0.0d,
                Customer5Price = 0.0d,
                Customer5Tip = 0.0d,
                Customer5ServiceFee = 0.0d,
                Customer6Price = 0.0d,
                Customer6Tip = 0.0d,
                Customer6ServiceFee = 0.0d,
                Customer7Price = 0.0d,
                Customer7Tip = 0.0d,
                Customer7ServiceFee = 0.0d,
                Customer8Price = 0.0d,
                Customer8Tip = 0.0d,
                Customer8ServiceFee = 0.0d,
                Customer9Price = 0.0d,
                Customer9Tip = 0.0d,
                Customer9ServiceFee = 0.0d,
                Customer10Price = 0.0d,
                Customer10Tip = 0.0d,
                Customer10ServiceFee = 0.0d,
                CustomerPaymentsTotal = 37.21d,
                ServiceFeeTotal = 3.87d
            });

        modelBuilder.Entity<Customer>()
            .HasData(
            new Customer
            {
                Id = -1,
                CustomerPrice = 22.15d,
                CustomerTip = 6.56d,
                CustomerServiceFee = 13.63d,
                Description = "Customer 1 Description",
                TripId = -1
            },
            new Customer
            {
                Id = -2,
                CustomerPrice = 12.99d,
                CustomerTip = 5.5d,
                CustomerServiceFee = 3.87d,
                Description = "Customer 1 Description",
                TripId = -2
            },
            new Customer
            {
                Id = -3,
                CustomerPrice = 9.3d,
                CustomerTip = 17.23d,
                CustomerServiceFee = 4.38d,
                Description = "Customer 1 Description",
                TripId = -3
            },
            new Customer
            {
                Id = -4,
                CustomerPrice = 10.49d,
                CustomerTip = 22.68d,
                CustomerServiceFee = 5.32d,
                Description = "Customer 2 Description",
                TripId = -3
            },
            new Customer
            {
                Id = -5,
                CustomerPrice = 1.0d,
                CustomerTip = 8.11d,
                CustomerServiceFee = 4.38d,
                Description = "Customer 1 Description",
                TripId = -4
            },
            new Customer
            {
                Id = -6,
                CustomerPrice = 1.85d,
                CustomerTip = 1.0d,
                CustomerServiceFee = 5.32d,
                Description = "Customer 2 Description",
                TripId = -4
            },
            new Customer
            {
                Id = -7,
                CustomerPrice = 2.25d,
                CustomerTip = 5.0d,
                CustomerServiceFee = 4.38d,
                Description = "Customer 1 Description",
                TripId = -5
            },
            new Customer
            {
                Id = -8,
                CustomerPrice = 2.0d,
                CustomerTip = 5.0d,
                CustomerServiceFee = 5.32d,
                Description = "Customer 2 Description",
                TripId = -5
            },
            new Customer
            {
                Id = -9,
                CustomerPrice = 17.84d,
                CustomerTip = 15.5d,
                CustomerServiceFee = 3.87d,
                Description = "Customer 1 Description",
                TripId = -6
            });
        base.OnModelCreating(modelBuilder);


        // Configure the relationships


        // MetaData has one Trip (one-to-many)
        modelBuilder.Entity<MetaData>()
            .HasOne(m => m.Trip) // MetaData has one Trip
            .WithMany(t => t.MetaDataList) // Trip can have many MetaData records
            .HasForeignKey(m => m.TripId); // Foreign key relationship

        // Customer has one Trip (one-to-many)
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Trip) // MetaData has one Trip
            .WithMany(t => t.Customers) // Trip can have many Customers
            .HasForeignKey(c => c.TripId); // Foreign key relationship
    }
}
