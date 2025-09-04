using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization; //CultureInfo
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Uber_Eats_Trip_Delivery_Portfolio_Project.FileDataManipulator;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    public class CSVCreator
    {
        private string _filePath;

        public CSVCreator(string filePath)
        {
            _filePath = filePath;
        }

        public void PreprocessData(List<FileDataManipulator> trips)
        {
            foreach (var trip in trips)
            {
                while (trip.Customers.Count < 10)
                { //make sure the static variable is discounted and id uneffected by these dummy objects 
                    trip.Customers.Add(new CustomerInfo(0) 
                    { 
                        Price = 0.0d, 
                        Tip = 0.0d,
                        ServiceFeeInfo = new UEServiceFeeInfo() { ServiceFee = 0.0d }
                    });
                }
            }
        }

        public List<FlattenedFileDataManipulator> FlattenData(List<FileDataManipulator> trips)
        {
            var flattenedTrips = new List<FlattenedFileDataManipulator>();

            foreach (var trip in trips)
            {
                var flattenedTrip = new FlattenedFileDataManipulator();

                // Copy your existing FileDataManipulator properties
                flattenedTrip.StoreName = trip.StoreName;
                flattenedTrip.Address = trip.Address;
                flattenedTrip.Street = trip.Street;
                flattenedTrip.City = trip.City;
                flattenedTrip.State = trip.State;
                flattenedTrip.Zip = trip.Zip;
                flattenedTrip.Country = trip.Country;
                flattenedTrip.Duration = trip.Duration;
                flattenedTrip.Distance = trip.Distance;
                flattenedTrip.DateTime = trip.DateTime;
                flattenedTrip.PointsEarned = trip.PointsEarned;
                flattenedTrip.Fare = trip.Fare;
                flattenedTrip.Promotion = trip.Promotion;
                flattenedTrip.Boost = trip.Boost;
                flattenedTrip.Tip = trip.Tip;
                flattenedTrip.YourEarnings = trip.YourEarnings;

                flattenedTrip.CustomerPaymentsTotal = trip.CustomerPaymentsTotal;
                flattenedTrip.ServiceFeeTotal = trip.ServiceFeeTotal;

                // Copy properties for up to 10 customers
                for (int i = 0; i < 10; i++)
                {
                    if (i < trip.Customers.Count)
                    {
                        switch (i)
                        {
                            case 0:
                                flattenedTrip.Customer1Price = trip.Customers[i].Price;
                                flattenedTrip.Customer1Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer1ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 1:
                                flattenedTrip.Customer2Price = trip.Customers[i].Price;
                                flattenedTrip.Customer2Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer2ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 2:
                                flattenedTrip.Customer3Price = trip.Customers[i].Price;
                                flattenedTrip.Customer3Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer3ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 3:
                                flattenedTrip.Customer4Price = trip.Customers[i].Price;
                                flattenedTrip.Customer4Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer4ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 4:
                                flattenedTrip.Customer5Price = trip.Customers[i].Price;
                                flattenedTrip.Customer5Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer5ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 5:
                                flattenedTrip.Customer6Price = trip.Customers[i].Price;
                                flattenedTrip.Customer6Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer6ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 6:
                                flattenedTrip.Customer7Price = trip.Customers[i].Price;
                                flattenedTrip.Customer7Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer7ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 7:
                                flattenedTrip.Customer8Price = trip.Customers[i].Price;
                                flattenedTrip.Customer8Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer8ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 8:
                                flattenedTrip.Customer9Price = trip.Customers[i].Price;
                                flattenedTrip.Customer9Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer9ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                            case 9:
                                flattenedTrip.Customer10Price = trip.Customers[i].Price;
                                flattenedTrip.Customer10Tip = trip.Customers[i].Tip;
                                flattenedTrip.Customer10ServiceFee = trip.Customers[i].ServiceFeeInfo.ServiceFee;
                                break;
                        }
                    }
                }

                flattenedTrips.Add(flattenedTrip);
            }

            return flattenedTrips;
        }

        public void CreateCSV(List<FlattenedFileDataManipulator> flattenedTrips)
        {
            using (var writer = new StreamWriter(_filePath)) 
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<FlattenedFileDataManipulatorMap>(); //The line csv.Context.RegisterClassMap<FlattenedFileDataManipulatorMap>(); tells CsvHelper to use your custom mapping when writing the records.
                csv.WriteRecords(flattenedTrips); 
            }
        }
    }
}
