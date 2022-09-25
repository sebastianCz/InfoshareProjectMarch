using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OstreC.Paragraph;

namespace OstreC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var listParagraphSerializedPath = Path.Combine(currentDirectory, "data", "dataJson", "listParagraph.json");

            string listParagraphSerialize = File.ReadAllText(listParagraphSerializedPath);

            ListParagraph Paragraph = JsonConvert.DeserializeObject<ListParagraph>(listParagraphSerialize);

            int idParagraph = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Paragraph.Paragraph[idParagraph].TextParagraph);
                Console.ResetColor();

                idParagraph = ChoiceParagraph.NextParagraph(Paragraph.Paragraph[idParagraph].HowManyOptions, Paragraph.Paragraph[idParagraph].NextParagraph);

            } while (idParagraph != 0);
        }
    }
}

