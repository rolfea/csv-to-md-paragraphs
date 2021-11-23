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
            string outputPath = $"{Environment.CurrentDirectory}/{args[2]}.md";
            string finalText = "";
            
            Console.WriteLine(outputPath);
            using (TextFieldParser parser = new TextFieldParser(filePath)) 
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                SkipLine(parser);

                while (!parser.EndOfData) 
                {
                    string[] row = parser.ReadFields();
                    
                    for (int i = 0; i < row.Length; i++)
                    {
                        var headerSize = i == 0 ? "##" : "###";
                        finalText += CreateTemplateSubsection(row[i], headerSize);
                    }
                }
            }            

            if (!File.Exists(outputPath))
            {                
                File.WriteAllText(outputPath, finalText);
            }
        }

        private static string CreateTemplateSubsection(string cell, string headerSize)
        {
            // this is ugly and brittle
            return 
            @$"{headerSize} {cell}

";
        }

        private static void SkipLine(TextFieldParser parser)
        {
            if (!parser.EndOfData) 
            {
                parser.ReadLine();
            }

        }

    }
}
