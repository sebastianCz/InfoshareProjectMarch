using OstreC.Services;
using OstreC;
using static OstreC.UI;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OstreC
{
    public interface IuiInterface
    {
        //PageType ==enum in UI.cs
        PageType  Type { get; }

        //String containing information to be drawn below headers. Headers can contain inventory state for instance + commands user can write.
        public string pageInfo { get; set; }

        //Check User Input depending on currently active page. 
        public void checkUserInput()
        {

           
        }

    }
    //Different Enum for each page requiring a different type of checks. So essentially the entire program paragraphs excluded.
    public enum PageType
    {
        mainMenu,
        createCharacter,
        createNewGame,
        loadGame,
        paragraphCombat,
        paragraphDialogue
    }


    public abstract  class Page
    {
        public PageType Type { get; }
        public int activePageNr { get; set; }
        
        //Name of active Page
        public string activePageName { get; set; }
       
        public Page()
        {



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

    public class MainMenuInput : Page, IuiInterface
    {
      
        public PageType Type => PageType.mainMenu;
        public string pageInfo { get; set; }

       
        public void checkUserInput()
        {
            Console.WriteLine("I'm the main menu");
           
        }



    }





}
