using Uber_Eats_Trip_Delivery_Portfolio_Project;

/*
 * Created Text File(s)
 * Now manipulate the text file(s)
 */

/*
 *                              START THE CHAIN OF EVENTS
 */

PdfToTextFileBatchConverter converter = new PdfToTextFileBatchConverter();
TripListCreator listMaker = new TripListCreator(converter);

CSVCreator csvCreator = new CSVCreator(@"C:\Users\alpha\source\repos\Uber-Eats-Trip-Delivery-Portfolio-Project\Uber Eats Trip Delivery Portfolio Project\resources\csv\ueDeliveryTrips.csv");
csvCreator.PreprocessData(listMaker.trips);

// Flatten the data and write it to the CSV file
var flattenedTrips = csvCreator.FlattenData(listMaker.trips);
csvCreator.CreateCSV(flattenedTrips);













