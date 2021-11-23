using System;
using Microsoft.VisualBasic.FileIO;

namespace csv_to_md
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[1];                        
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
        }
    }
}
