using iTextSharp.text.pdf.parser; // iTextSharpDemo
using iTextSharp.text.pdf; // iTextSharpDemo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // iTextSharpDemo
using System.Threading.Tasks;

namespace Uber_Eats_Trip_Delivery_Portfolio_Project
{
    public class PdfToTextConverter
    {
        // Private Fields 
        private string directory;
        private string inputFileName;
        private string path;
        private string outputFileName;
        private static int count = 0;

        //Create Constructor 
        public PdfToTextConverter()
        {

        }

        public PdfToTextConverter(string directory, string inputFileName, string outputFileName)
        {
            this.directory = directory;
            this.inputFileName = inputFileName;
            this.path = $"{directory}{inputFileName}";
            this.outputFileName = outputFileName;
            count += 1;
        }

        public void WriteToTextFile()
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                using (StreamWriter writer = new StreamWriter(System.IO.Path.Combine(@"C:\Users\alpha\source\repos\Uber-Eats-Trip-Delivery-Portfolio-Project\Uber Eats Trip Delivery Portfolio Project\resources\trips\", outputFileName)))
                {
                    writer.Write(text.ToString());
                }
            }
        }


        public void ConvertPdfToTxtFile()
        {
            WriteToTextFile();
            Console.WriteLine("{0} Text Files Created.", count.ToString());
        }

        public int GetCount()
        {
            return count;
        }

    }

    /*
     * Wow!
     */
}

/*
static void Main(string[] args)
{
    var ExtractedPdfToString
    = ExtractTextFromPdf(@"C:\Users\alpha\OneDrive\Desktop\trip.pdf");
    Console.Write(ExtractedPdfToString);
}
*/