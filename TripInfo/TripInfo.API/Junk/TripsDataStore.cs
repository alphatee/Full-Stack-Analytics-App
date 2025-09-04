using System.Diagnostics.Metrics;
using System.IO;
using TripInfo.API.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace TripInfo.API
{
    public class TripsDataStore
    {
        public List<TripDto> Trips { get; set; }
        // public static TripsDataStore Current { get; } = new TripsDataStore(); // singleton pattern, there is only one datastore. Dependency Injection could be used to improve on this.

        public TripsDataStore()
        {
            // init dummy data 
            Trips = new List<TripDto>()
            {
                new TripDto()
                {
                    Id = 1,
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
                    ServiceFeeTotal = 13.63d,
                    Customers = new List<CustomerDto>()
                    {
                        new CustomerDto()
                        {
                            Id = 1,
                            CustomerPrice = 22.15d,
                            CustomerTip = 6.56d,
                        },
                    }
                },
                new TripDto()
                {
                    Id = 2,
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
                    ServiceFeeTotal = 3.87d,
                    Customers = new List<CustomerDto>()
                    {
                        new CustomerDto()
                        {
                            Id = 1,
                            CustomerPrice = 12.99d,
                            CustomerTip = 5.5d,
                            CustomerServiceFee = 3.87d,
                        },
                    }
                },
                new TripDto()
                {
                    Id = 3,
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
                    ServiceFeeTotal = 9.7d,
                    Customers = new List<CustomerDto>()
                    {
                        new CustomerDto()
                        {
                            Id = 1,
                            CustomerPrice = 9.3d,
                            CustomerTip = 17.23d,
                            CustomerServiceFee = 4.38d,
                        },
                        new CustomerDto()
                        {
                            Id = 2,
                            CustomerPrice = 10.49d,
                            CustomerTip = 22.68d,
                            CustomerServiceFee = 5.32d,
                        },
                    }
                }
            };
        }
    }
}
