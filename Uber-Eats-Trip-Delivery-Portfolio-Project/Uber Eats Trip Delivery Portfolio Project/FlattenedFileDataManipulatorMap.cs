using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    public class FlattenedFileDataManipulatorMap : ClassMap<FlattenedFileDataManipulator>
    {
        public FlattenedFileDataManipulatorMap()
        {
            Map(m => m.StoreName).Name("Store Name");
            Map(m => m.Address).Name("Address");
            Map(m => m.Street).Name("Street");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.Zip).Name("Zip");
            Map(m => m.Country).Name("Country");
            Map(m => m.Duration).Name("Duration");
            Map(m => m.Distance).Name("Distance");
            Map(m => m.DateTime).Name("DateTime");
            Map(m => m.PointsEarned).Name("Points Earned");

            Map(m => m.Fare).Name("Fare");
            Map(m => m.Promotion).Name("Promotion");
            Map(m => m.Boost).Name("Boost");
            Map(m => m.Tip).Name("Tip");
            Map(m => m.YourEarnings).Name("Your Earnings");

            // Map up to 10 customers
            Map(m => m.Customer1Price).Name("Customer 1 Price");
            Map(m => m.Customer1Tip).Name("Customer 1 Tip");
            Map(m => m.Customer1ServiceFee).Name("Customer 1 Service Fee");

            Map(m => m.Customer2Price).Name("Customer 2 Price");
            Map(m => m.Customer2Tip).Name("Customer 2 Tip");
            Map(m => m.Customer2ServiceFee).Name("Customer 2 Service Fee");

            Map(m => m.Customer3Price).Name("Customer 3 Price");
            Map(m => m.Customer3Tip).Name("Customer 3 Tip");
            Map(m => m.Customer3ServiceFee).Name("Customer 3 Service Fee");

            Map(m => m.Customer4Price).Name("Customer 4 Price");
            Map(m => m.Customer4Tip).Name("Customer 4 Tip");
            Map(m => m.Customer4ServiceFee).Name("Customer 4 Service Fee");

            Map(m => m.Customer5Price).Name("Customer 5 Price");
            Map(m => m.Customer5Tip).Name("Customer 5 Tip");
            Map(m => m.Customer5ServiceFee).Name("Customer 5 Service Fee");

            Map(m => m.Customer6Price).Name("Customer 6 Price");
            Map(m => m.Customer6Tip).Name("Customer 6 Tip");
            Map(m => m.Customer6ServiceFee).Name("Customer 6 Service Fee");

            Map(m => m.Customer7Price).Name("Customer 7 Price");
            Map(m => m.Customer7Tip).Name("Customer 7 Tip");
            Map(m => m.Customer7ServiceFee).Name("Customer 7 Service Fee");

            Map(m => m.Customer8Price).Name("Customer 8 Price");
            Map(m => m.Customer8Tip).Name("Customer 8 Tip");
            Map(m => m.Customer8ServiceFee).Name("Customer 8 Service Fee");

            Map(m => m.Customer9Price).Name("Customer 9 Price");
            Map(m => m.Customer9Tip).Name("Customer 9 Tip");
            Map(m => m.Customer9ServiceFee).Name("Customer 9 Service Fee");

            Map(m => m.Customer10Price).Name("Customer 10 Price");
            Map(m => m.Customer10Tip).Name("Customer 10 Tip");
            Map(m => m.Customer10ServiceFee).Name("Customer 10 Service Fee");


            // Map the customer payments total and service fee total
            Map(m => m.CustomerPaymentsTotal).Name("Customer Payments Total");
            Map(m => m.ServiceFeeTotal).Name("Service Fee Total");
        }
    }

}
