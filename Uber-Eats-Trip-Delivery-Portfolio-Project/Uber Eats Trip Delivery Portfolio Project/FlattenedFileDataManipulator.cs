using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    public class FlattenedFileDataManipulator
    {
        // Your existing FileDataManipulator properties
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
        public DateTime DateTime { get; set; }
        public int PointsEarned { get; set; }
        public double Fare { get; set; }
        public double Promotion { get; set; }
        public double Boost { get; set; }
        public double Tip { get; set; }
        public double YourEarnings { get; set; }


        public double CustomerPaymentsTotal { get; set; } = 0.0d;

        public double ServiceFeeTotal { get; set; } = 0.0d;


        // Properties for up to 10 customers
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
    }
}
