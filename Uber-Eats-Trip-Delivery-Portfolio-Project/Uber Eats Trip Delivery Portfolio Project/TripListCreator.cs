using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    public class TripListCreator
    {
        // Private Fields
        private string txtFileDirectory;
        private FileDataManipulator trip;
        public List<FileDataManipulator> trips;

        // Constructor 
        public TripListCreator(PdfToTextFileBatchConverter converter)
        {
            txtFileDirectory = @"C:\Users\alpha\source\repos\Uber-Eats-Trip-Delivery-Portfolio-Project\Uber Eats Trip Delivery Portfolio Project\resources\trips\";
            trip = null;
            trips = new List<FileDataManipulator>(); // Creates List for trip objects 

            // Get a list of all the text files in the directory
            var files = Directory.GetFiles(txtFileDirectory, "*.txt");

            // Take all the text files and create a "FileDataManipulator" object
            foreach (var file in files)
            {
                //Console.WriteLine("Processing file: " + file); //helps with debugging
                trip = new FileDataManipulator(file);
                // START TEST DEBUGGER
                /*
                if (trip.StoreName == "Jersey Mike's Subs (San Diego)")
                {
                    Console.WriteLine("Found the store in file: " + file);
                }
                */
                // END TEST DEBUGGER
                trips.Add(trip);
            }

            // Take the "FileDataManipulator" objects and call the getCustomersInfo() method.
            foreach (var item in trips)
            {
                item.GetCustomersInfo();
            }
        }

        // Methods

        // Returns a list of my trip objects ...aka Get Trips (another idea for a good name)
        public List<FileDataManipulator> GetFileDataManipulators()
        {
            return trips;
        }

        public int GetCountTextFiles()
        {
            return trips.Count; // Returns the actual count of text files processed
        }
    }
}
