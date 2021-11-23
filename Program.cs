using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace csv_to_md
{
    class Program
    {
        static void Main(string[] args)
        {            
            string filePath = args[1];           
            string outputPath = Environment.CurrentDirectory + "/newFile.md";

            using (TextFieldParser parser = new TextFieldParser(filePath)) 
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData) 
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields) 
                    {
                        Console.WriteLine(field);
                    }
                }
            }

            if (!File.Exists(outputPath))
            {
                File.Create(outputPath);
            }
        }
    }
}
