using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    public class PdfToTextFileBatchConverter
    {
        // Private Fields
        private string pdfFileDirectory;
        private string pdfFileName;
        private string pdfFileExtension;
        private string outputFileName;
        private int countPdfFiles;
        private PdfToTextConverter textFile;
        private List<PdfToTextConverter> textFiles;
        string txtFileExtension;

        // Constructor
        public PdfToTextFileBatchConverter()
        {
            pdfFileDirectory = @"C:\Users\alpha\source\repos\Uber-Eats-Trip-Delivery-Portfolio-Project\Uber Eats Trip Delivery Portfolio Project\resources\pdf_files\";
            pdfFileName = "";
            pdfFileExtension = ".pdf";
            outputFileName = "";
            countPdfFiles = 1;
            textFile = null;
            textFiles = new List<PdfToTextConverter>();
            string txtFileExtension = ".txt";

            // Create Text Files
            for (int i = 1; i <= 224; i++)
            {
                pdfFileName = "trip" + i.ToString() + pdfFileExtension; //i.e., "trip1.pdf"
                outputFileName = "trip" + i.ToString() + txtFileExtension; //i.e., "trip1.txt"
                textFile = new PdfToTextConverter(pdfFileDirectory, pdfFileName, outputFileName);
                textFile.ConvertPdfToTxtFile();
                textFiles.Add(textFile);
                countPdfFiles++;
            }
            Console.WriteLine("------------------------");
        }

        // Methods

        // Returns list of the text files 
        public List<PdfToTextConverter> GetTextFiles()
        {
            return textFiles;
        }

        public int GetCountPdfFiles()
        {
            return countPdfFiles;
        }

    }
}
