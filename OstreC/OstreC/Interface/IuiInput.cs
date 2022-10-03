using OstreC.Services;
using OstreC;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
 

namespace OstreC
{
    public interface IuiInput
    {
        //PageType ==enum in UI.cs
        PageType  Type { get; }


        //Check User Input depending on currently active page. 
        public void checkUserInput(UI UI);
        

         
         

    }
    //Different Enum for each page requiring a different type of checks. So essentially the entire program paragraphs excluded.
    public enum PageType
    {
        Main_Menu,
        Create_NewGame,
        Create_Character,
        Load_Game,
        Paragraph,
        Bestiary
    }
   

    public   class Page
    {
        public PageType currentType { get; set; }


        public string error { get; set; } = "" ;
        public string instructions { get; set; }




        public static string breakLine = "\n=======================================================================================================\n";
        public Page(PageType x)
        {
            //Default value
            currentType =  x;

        }

    }

   
  

    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;
         
        
        public void checkUserInput(UI UI)
        {
            
            var input = Console.ReadLine();

            
            if (Helpers.isCommand(input,UI))
            {

                Helpers.HandleCommand(input, UI);
                    
             }

            //isNumber returns true if it's a number. Basicaly a premade bolean from try parse. 
            if (Helpers.isNumber(input))
            {

                if (input == "1")
                {
                    UI.Page.currentType = PageType.Create_NewGame;
                    
                }
                else if(input == "2")
                {
                    UI.Page.currentType = PageType.Create_Character;

                }else if(input == "4")
                {

                    UI.Page.currentType = PageType.Load_Game;
                }
                else if (input == "5")
                {

                    UI.Page.currentType = PageType.Paragraph;

                }else if(input == "6")
                {
                    UI.Page.currentType = PageType.Bestiary;

                }

            }
            else
            {
                UI.Page.error = "You didn't provide a correct number";

            }


            //ENUM iteration -> So options can be created dynamically without having to update the entire logic each time. 
            //foreach (int i  in Enum.GetValues(typeof(PageType)))
            //{
            //    pageInfo += ($"{Enum.GetName(typeof(PageType), i)}");


            //}

        }



    }

    public class CreateNewGameInput : IuiInput
    {
          public PageType Type => PageType.Create_NewGame;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here




        }

    }
    

    public class Create_Character : IuiInput
    {
        public PageType Type => PageType.Create_Character;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here




        }

    }

    public class Load_Game : IuiInput
    {
        public PageType Type => PageType.Load_Game;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here




        }

    }

    public class Paragraph : IuiInput
    {
        public PageType Type => PageType.Paragraph;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here




        }

    }

    public class Bestiary : IuiInput
    {
        public PageType Type => PageType.Bestiary;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here




        }

    }
 




}
//Console.WriteLine($"Current page: {activePageName} || page {activePageNr + 1} on {maxPagesNr} \n================================\n {header} \n============================ ");
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(error);
//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine(pageInfo);
//Console.ForegroundColor = ConsoleColor.White;




//public class ParagraphInput : IuiInterface
//  {
//      public PageType HandledType => PageType.paragraphDialogue;



//  }