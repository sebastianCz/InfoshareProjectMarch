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



           
            //Paragraph to display
           // int idParagraph = 0;
             
            //  Console.WriteLine($"Current directory:{currentDirectory} \n listparaserialised : {listParagraphSerializedPath}\n listparaserialize file:{listParagraphSerialize}\n Paragraph list : {Paragraph}\n id paragraph chocie paragraph{idParagraph}");
          


            //Game Ui object which will contain all methods to save, exit, check readLine input to see if it's an existing command or not. Redraw UI for all pages 
            //Game object init. Done once in the program. Sets default page to main menu
            var Game = new Game(0, "MAIN MENU" );
            Game.init();





          
            //Main game loop
            do
            {
                //Draws chosen page with error message. Used to display user input error msgs to user. Set Game.activePageNr if you want your code to switch page on next redraw  or Game.error if you wish to show an error message to use on next redraw;
                Game.redraw(Game.activePageNr,Game.error);
                //User input. 
                string input = Console.ReadLine();
                //Input validation -WIP
                inputValidation.inputCheck(ref Game, input);

               






            } while (!Game.exit );

            
           
           
           
           
            
//Starts game session, displays paragraphs and it's instructions
          
            void startGameSession(ref Game game) {

                //Paragraph object init
                var currentDirectory = Directory.GetCurrentDirectory();
                var listParagraphSerializedPath = Path.Combine(currentDirectory, "data", "dataJson", "listParagraph.json");

                string listParagraphSerialize = File.ReadAllText(listParagraphSerializedPath);

                ListParagraph Paragraph = JsonConvert.DeserializeObject<ListParagraph>(listParagraphSerialize);
                do
                {


                    // Console.Clear();
                    // Console.WriteLine(Paragraph.Paragraph[idParagraph].TextParagraph);
                    Game.pageInfo = Paragraph.Paragraph[Game.paragraphID].TextParagraph;
                     Game.paragraphID = ChoiceParagraph.NextParagraph(Paragraph.Paragraph[Game.paragraphID].HowManyOptions, Paragraph.Paragraph[Game.paragraphID].NextParagraph);

                //idParagraph = ChoiceParagraph.NextParagraph(Paragraph.Paragraph[idParagraph].HowManyOptions, Paragraph.Paragraph[idParagraph].NextParagraph)
              } while (Game.paragraphID != 0);
          
            }

        }
    }
}

