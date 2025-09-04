using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    /*
     * textFile is for example: "trip3.txt" 
     */
    public class FileDataManipulator
    {
        private string[] source;
        Regex regex;
        Match match;

        //ParseMetaData
        private string[] metaDataInfo; 
        private string storeName;
        private string address;
        private string street;
        private string city;
        private string state;
        private string zip;
        private string country;
        private TimeSpan duration;
        private TimeSpan parsedDuration;
        private double distance;
        private DateTime dateTime;
        private int pointsEarned;

        //ParseIncome
        private string[] incomeInfo;
        private double fare;
        private double promotion;
        private double boost;
        private double tip;
        private double yourEarnings;

        //ParseCustomerPayment
        private string[] customerPaymentsInfo;
        private List<CustomerInfo> customers;
        private CustomerInfo currentCustomer;   
        private double customerPaymentsTotal;   //I need this
        private int countCustomer;
        public List<CustomerInfo> Customers 
        { 
            get { return customers; } 
            set { customers = value; } 
        }

        public double CustomerPaymentsTotal
        {
            get { return customerPaymentsTotal; }
            set { customerPaymentsTotal = value; }
        }

        //ParseUEServiceFee
        private string[] ueServiceFeesInfo;
        private double serviceFeeTotal; //I need this

        public double ServiceFeeTotal
        {
            get { return serviceFeeTotal; }
            set { serviceFeeTotal = value; }
        }

        /*
         * public properties
        */

        // ParseMetaData
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

        // ParseIncome
        public double Fare { get; set; }
        public double Promotion { get; set; }
        public double Boost { get; set; }
        public double Tip { get; set; }
        public double YourEarnings { get; set; }

        /*
         * Constructor
         */
        public FileDataManipulator(string textFile)
        {
            source = System.IO.File.ReadAllLines(textFile);
            regex = new Regex(@"([\d,.]+)");
            match = Match.Empty;

            // ParseMetaData
            metaDataInfo = FindMetaDataInfo();
            StoreName = "";
            Address = "";
            Street = "";
            City = "";
            State = "";
            Zip = "";
            Country = "";
            Duration = new TimeSpan();
            parsedDuration = new TimeSpan();
            Distance = 0.0d;
            DateTime = DateTime.MinValue;
            PointsEarned = 0;

            // ParseIncome
            incomeInfo = FindIncomeInfo();
            Fare = 0.0d;
            Promotion = 0.0d;
            Boost = 0.0d;
            Tip = 0.0d;
            YourEarnings = 0.0d;

            //ParseCustomerPayment
            customerPaymentsInfo = FindCustomerPaymentsInfo();
            customers = new List<CustomerInfo>();
            currentCustomer = null;
            CustomerPaymentsTotal = 0.0d;
            countCustomer = 0; //keep track of which customer


            //ParseUEServiceFee
            ueServiceFeesInfo = FindUEServiceFeesInfo();
            ServiceFeeTotal = 0.0d;

            // Call method to process file
            ProcessFile(textFile);
        }

        /*
         * Methods
         */
        private void ProcessFile(string textFile)
        {
            ParseMetaData();
            ParseIncome();
            ParseCustomerPayment();
            ParseUEServiceFee();
        }

        private void ParseMetaData()
        {
            //changed these two for the public properties for csvHelper: StoreName & Address
            string storeNameInfo = metaDataInfo[0];

            if (metaDataInfo.Length > 1 && metaDataInfo[1].Contains(")"))
            {
                storeNameInfo += metaDataInfo[1];
            }

            if (storeNameInfo.Contains(")"))
            {
                StoreName = storeNameInfo.Substring(0, storeNameInfo.IndexOf(")") + 1);
            }
            else
            {
                StoreName = metaDataInfo[0];
            }

            // Determine the index where the address starts
            int addressIndex = storeNameInfo == metaDataInfo[0] ? 1 : 2;

            Address = metaDataInfo[addressIndex];

            //parse address 
            var addressString = string.Join(", ", metaDataInfo.Skip(addressIndex).TakeWhile(line => !line.Contains("Duration", StringComparison.OrdinalIgnoreCase)));
            string[] addressArray = addressString.Split(", ");

            if (addressArray.Length >= 4)
            {
                Street = addressArray[0];
                City = addressArray[1];

                //parse State 
                State = addressArray[2].Substring(0, 2);

                /*parse zip: This code will match a 5-digit zip code. 
                 * If the input string contains such a pattern, it will be extracted and printed. */
                var subStringZip = addressArray[2];
                match = Regex.Match(subStringZip, @"\b\d{5}\b");
                if (match.Success)
                {
                    Zip = match.Value;
                }

                Country = addressArray[3];
            }
            else
            {
                // Handle the case where addressArray does not have the required number of elements
                // You could set some default values, throw an exception, or handle this situation in another way that makes sense for your application
            }
            //end parsing for address

            //Parse Duration
            string time = "";

            for (int i = 0; i < metaDataInfo.Length - 1; i++)
            {
                if (metaDataInfo[i].Contains("Duration", StringComparison.OrdinalIgnoreCase))
                {
                    time = metaDataInfo[i + 1];
                    time = time.Trim(); // Remove any extra spaces

                    // Check if the time string contains "hr"
                    if (time.Contains("hr"))
                    {
                        // Split the time string on spaces and parse the hours and minutes
                        string[] parts = time.Split(' ');
                        int hours = int.Parse(parts[0]);
                        int minutes = int.Parse(parts[2]);
                        // Convert the time to a TimeSpan
                        parsedDuration = new TimeSpan(hours, minutes, 0);
                    }
                    else // The time string is in "min sec" format
                    {
                        // Split the time string on spaces and parse the minutes and seconds
                        string[] parts = time.Split(' ');
                        int minutes = int.Parse(parts[0]);
                        int seconds = int.Parse(parts[2]);
                        // Convert the time to a TimeSpan
                        parsedDuration = new TimeSpan(0, minutes, seconds);
                    }
                    break;
                }
            }

            // Assign the parsed duration to the Duration property
            Duration = parsedDuration;
            //end parsing for duration

            //Parse Distance 
            for (int i = 0; i < metaDataInfo.Length - 1; i++)
            {
                if (metaDataInfo[i].Contains("Distance", StringComparison.OrdinalIgnoreCase))
                {
                    string[] parts = metaDataInfo[i + 1].Split(' ');
                    Distance = Convert.ToDouble(parts[0]);
                    break;
                }
            }

            //Parse Time Requested + Parse Date Requested 
            string timeString = "";
            DateTime timedt = DateTime.MinValue;
            string dateString = "";
            DateTime date = DateTime.MinValue;

            for (int i = 0; i < metaDataInfo.Length - 1; i++)
            {
                if (metaDataInfo[i].Contains("Time Requested", StringComparison.OrdinalIgnoreCase))
                {
                    timeString = metaDataInfo[i + 1];
                    timedt = DateTime.Parse(timeString);
                }

                if (metaDataInfo[i].Contains("Date Requested", StringComparison.OrdinalIgnoreCase))
                {
                    dateString = metaDataInfo[i + 1];
                    date = DateTime.Parse(dateString);
                    break;
                }
            }
            DateTime = new DateTime(date.Year, date.Month, date.Day, timedt.Hour, timedt.Minute, timedt.Second);
            //Parse Time Requested + Parse Date Requested  ENDED

            //Parse Points Earned
            for (int i = 0; i < metaDataInfo.Length - 1; i++)
            {
                if (metaDataInfo[i].Contains("Points Earned", StringComparison.OrdinalIgnoreCase))
                {
                    string s = metaDataInfo[i + 1];
                    string[] parts = s.Split(' ');
                    int points;
                    if (int.TryParse(parts[0], out points))
                    {
                        PointsEarned = points;
                    }
                    break;
                }
            }
            //Parse Points Earned ENDED
        }

        private void ParseIncome()
        {
            for (int i = 0; i < incomeInfo.Length - 1; i++)
            {
                // Split the line into parts using the '$' as the separator
                string[] parts = incomeInfo[i].Split('$');

                if (incomeInfo[i].Contains("Fare", StringComparison.OrdinalIgnoreCase))
                {
                    // If the value is not on the same line, check the next line
                    if (i + 1 < incomeInfo.Length)
                    {
                        string[] nextLineParts = incomeInfo[i + 1].Split('$');
                        if (nextLineParts.Length > 1)
                        {
                            // Split the second part at the first occurrence of a non-numeric character
                            string[] subParts = Regex.Split(nextLineParts[1].Trim(), @"[^0-9\.]+");

                            // Check if the first sub-part is a valid double
                            if (subParts.Length > 0 && double.TryParse(subParts[0].Trim(), out double value))
                            {
                                Fare = value;
                            }
                        }
                    }
                }

                if (incomeInfo[i].Contains("Promotion", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if there is a second part and if it is a valid double
                    if (parts.Length > 1 && double.TryParse(parts[1].Replace("$", "").Trim(), out double value))
                    {
                        Promotion = value;
                    }
                    else
                    {
                        // If the value is not on the same line, check the next line
                        if (i + 1 < incomeInfo.Length && double.TryParse(incomeInfo[i + 1].Replace("$", "").Trim(), out value))
                        {
                            Promotion = value;
                        }
                    }
                }

                if (incomeInfo[i].Contains("Boost", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if there is a second part and if it is a valid double
                    if (parts.Length > 1 && double.TryParse(parts[1].Replace("$", "").Trim(), out double value))
                    {
                        Boost = value;
                    }
                    else
                    {
                        // If the value is not on the same line, check the next line
                        if (i + 1 < incomeInfo.Length && double.TryParse(incomeInfo[i + 1].Replace("$", "").Trim(), out value))
                        {
                            Boost = value;
                        }
                    }
                }

                if (incomeInfo[i].Contains("Tip", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if there is a second part and if it is a valid double
                    if (parts.Length > 1 && double.TryParse(parts[1].Replace("$", "").Trim(), out double value))
                    {
                        Tip = value;
                    }
                    else
                    {
                        // If the value is not on the same line, check the next line
                        if (i + 1 < incomeInfo.Length && double.TryParse(incomeInfo[i + 1].Replace("$", "").Trim(), out value))
                        {
                            Tip = value;
                        }
                    }
                }

                if (incomeInfo[i].Contains("Your earnings", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if there is a second part and if it is a valid double
                    if (parts.Length > 1 && double.TryParse(parts[1].Replace("$", "").Trim(), out double value))
                    {
                        YourEarnings = value;
                    }
                    else
                    {
                        // If the value is not on the same line, check the next line
                        if (i + 1 < incomeInfo.Length && double.TryParse(incomeInfo[i + 1].Replace("$", "").Trim(), out value))
                        {
                            YourEarnings = value;
                        }
                    }
                }
            }
        }

        private void ParseCustomerPayment()
        {
            regex = new Regex(@"([\d,.]+)");
            match = Match.Empty;

            for (int i = 1; i != customerPaymentsInfo.Length; i++) // i = 1 to skip "Customer payments" at index 0
            {
                if (customerPaymentsInfo[i].Contains("Customer price"))
                {
                    currentCustomer = new CustomerInfo(++countCustomer);
                    match = regex.Match(customerPaymentsInfo[i + 1]);

                    if (match.Success)
                    {
                        currentCustomer.Customer = countCustomer;
                        currentCustomer.Price = Convert.ToDouble(match.Groups[1].Value);
                        currentCustomer.CustomerTotal += currentCustomer.Price;
                        customers.Add(currentCustomer);
                    }
                }

                if (customerPaymentsInfo[i].Contains("Tip"))
                {
                    match = regex.Match(customerPaymentsInfo[i + 1]);

                    if (match.Success)
                    {
                        currentCustomer.Tip = Convert.ToDouble(match.Groups[1].Value);
                        currentCustomer.CustomerTotal += currentCustomer.Tip;
                    }
                }

                if (customerPaymentsInfo[i].Contains("Total"))
                {
                    match = regex.Match(customerPaymentsInfo[i + 1]);

                    if (match.Success)
                    {
                        break;
                    }
                }
            }
            CalculateTotalCustomerPayments(); //store customer payment total for the instance of a trip
        }


        private void ParseUEServiceFee()
        {
            regex = new Regex(@"([\d,.]+)");
            match = Match.Empty;
            var customer = 0; //enter service fee by tracking the customer in the customercurrentCustomer.ServiceFeeInfo.ServiceFee list 

            for (int i = 1; i != ueServiceFeesInfo.Length; i++) // i = 1 to skip "Customer payments" at index 0
            {
                if (ueServiceFeesInfo[i].Contains("Service Fee"))
                {
                    if (customer < customers.Count)
                    {
                        CustomerInfo currentCustomer = customers[customer++];
                        match = regex.Match(ueServiceFeesInfo[i + 1]);

                        if (match.Success)
                        {
                            currentCustomer.ServiceFeeInfo.ServiceFee = Convert.ToDouble(match.Groups[1].Value);
                        }
                    }
                    else
                    {
                        // Handle the situation when there are no more customers in the list
                        break;
                    }
                }

                if (ueServiceFeesInfo[i].Contains("Total"))
                {
                    // Check if the dollar amount is on the same line as "Total"
                    match = regex.Match(ueServiceFeesInfo[i]);
                    if (!match.Success && i < ueServiceFeesInfo.Length - 1)
                    {
                        // If not, try to match on the next line
                        match = regex.Match(ueServiceFeesInfo[i + 1]);
                    }

                    if (match.Success)
                    {
                        break;
                    }
                }
            }
            CalculateServiceFeeTotal(); //store service fee total for the instance of a trip
        }

        public static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private void CalculateServiceFeeTotal()
        {
            foreach(var item in customers) 
            {
                ServiceFeeTotal += item.ServiceFeeInfo.ServiceFee;
            }
        }

        private void CalculateTotalCustomerPayments()
        {
            foreach(var item in customers)
            {
                CustomerPaymentsTotal += (item.Price + item.Tip);
            }
        }

        private string[] FindMetaDataInfo()
        {
            var end = 0;
            var sizeOfArray = 0;

            for (int i = 0; i < source.Length - 1; i++)
            {
                if (source[i].Contains("Paid to you"))
                {
                    end = i;
                    sizeOfArray = end + 1; //go one past for null value
                    break;
                }
            }

            return SubArray(source, 0, sizeOfArray);
        }

        private string[] FindIncomeInfo()
        {
            var beginning = 0;
            var end = 0;
            var sizeOfArray = 0;

            for (int i = 0; i < source.Length - 1; i++)
            {
                if (source[i].Contains("Paid to you"))
                {
                    beginning = i;
                }

                if (source[i].Contains("Your earnings"))
                {
                    end = i + 1; //The number after this phrase is the end of the array.
                    sizeOfArray = end - beginning + 1; //go one past for null value
                    break;
                }
            }

            return SubArray(source, beginning, sizeOfArray);
        }

        private string[] FindCustomerPaymentsInfo()
        {
            var beginning = 0;
            var end = 0;
            var sizeOfArray = 0;

            for (int i = 0; i < source.Length - 1; i++)
            {
                if (source[i].Contains("Customer payments"))
                {
                    beginning = i;
                }

                if (source[i].Contains("Paid to Uber"))
                {
                    end = i;
                    sizeOfArray = end - beginning + 1; //go one past for null value
                    break;
                }
            }

            return SubArray(source, beginning, sizeOfArray);
        }

        private string[] FindUEServiceFeesInfo()
        {
            var beginning = 0;
            var end = source.Length - 1; //Set end to be the last index of source
            var sizeOfArray = 0;

            for (int i = 0; i < source.Length - 1; i++)
            {
                if (source[i].Contains("Paid to Uber"))
                {
                    beginning = i;
                    break;
                }
            }

            sizeOfArray = end - beginning + 1; //go one past for null value

            return SubArray(source, beginning, sizeOfArray);
        }

        //a handy method to display information from my collection of CustomerInfo objects
        public void GetCustomersInfo()
        {
            var totalCount = customers.Count(); //Console.WriteLine(totalCount);
            var count = 0;

            Console.WriteLine(StoreName);
            Console.WriteLine(Address);
            Console.WriteLine("The duration was {0}", duration);
            Console.WriteLine(Distance + " miles.");
            Console.WriteLine(DateTime);
            Console.WriteLine(PointsEarned + " points earned.");

            Console.WriteLine("Your fare = ${0}", Fare.ToString("F2"));
            Console.WriteLine("Your promotion = ${0}", Promotion.ToString("F2"));
            Console.WriteLine("Your boost = ${0}", Boost.ToString("F2"));
            Console.WriteLine("Total tip included = ${0}", Tip.ToString("F2"));
            Console.WriteLine("Your Earnings = ${0}", YourEarnings.ToString("F2"));
            Console.WriteLine();

            Console.WriteLine("The number of customers for this delivery trip were {0}", customers.Count());
            Console.WriteLine("------------------------");

            //for(int count = 0; count < totalCount; count++) 
            foreach (var item in customers)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("-   Delivery Trip {0}  -", item.Customer.ToString());
                Console.WriteLine("------------------------");
                Console.WriteLine("{0} paid a total ${1}", item.ID, item.CustomerTotal.ToString("F2"));
                Console.WriteLine("The price paid by {0} = ${1}", item.ID, item.Price.ToString("F2"));
                Console.WriteLine("The tip paid by {0} = ${1}", item.ID, item.Tip.ToString("F2"));
                Console.WriteLine("{0} paid to Uber a Service Fee of ${1}", item.ID, item.ServiceFeeInfo.ServiceFee.ToString("F2"));
                Console.WriteLine("------------------------");
                Console.WriteLine("The Total Service Fees paid to Uber are ${0}", ServiceFeeTotal.ToString("F2"));
                //[LOW PRIORITY]figure out how to make this work for all cases
                //if(8 != customers.Count())
                //{
                //    Console.WriteLine("The combined total of customer prices and tips are ${0}", CustomerPaymentsTotal);
                //    Console.WriteLine("------------------------");
                //}
                Console.WriteLine("The combined total of customer prices and tips are ${0}", CustomerPaymentsTotal.ToString("F2"));
                Console.WriteLine("------------------------");
            }
        }

        /*
         * Nested Classes
         */
        public class CustomerInfo
        {
            private static int countCustomers = 0; //If I ever want to keep track of every customer created with this class
            private double customerTotal = 0.0d;

            public static int CountCustomers
            {
                get { return countCustomers; }
                private set { countCustomers = value; }
            }

            public double CustomerTotal
            {
                get { return customerTotal; }
                set { customerTotal = value; }
            }

            public string ID { get; private set; }
            public int Customer { get; set; }
            public double Price { get; set; }
            public double Tip { get; set; }

            // Add a UEServiceFeeInfo property to the CustomerInfo class
            public UEServiceFeeInfo ServiceFeeInfo { get; set; }

            public CustomerInfo(int id)
            {
                CountCustomers++;
                ID = "Customer " + id.ToString();
                Customer = 1;
                Price = 0.0d;
                Tip = 0.0d;

                // Initialize the UEServiceFeeInfo property in the constructor
                ServiceFeeInfo = new UEServiceFeeInfo();
            }
        }

        public class UEServiceFeeInfo
        {
            public double ServiceFee { get; set; }

            public UEServiceFeeInfo() 
            { 
                ServiceFee = 0.0d;
            }
        }
    }
}
