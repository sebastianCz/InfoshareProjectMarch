using OstreC.Services;
using OstreC;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
 

namespace OstreC.Interface
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
        Main_Menu ,
        Create_NewGame,
        Create_Character,
        Load_Game,
        Paragraph,
        Paragraph_Combat,
        Bestiary,
        ExampleEnum
    }
   

    public   class Page
    {
        public PageType currentType { get; set; }
        public string breakLine { get; } = "\n=======================================================================================================\n";

        public string pageInfo { get; set; } = "";
        public string error { get; set; } = "" ;
        public string instructions { get; set; } = "";

       


        public Page(PageType x)
        {
            //Default value
            currentType =  x;

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