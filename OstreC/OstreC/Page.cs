using OstreC.Services;
using OstreC;
using OstreC.Interface;
using OstreC.ManageInput;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace OstreC
{
    public class Page
    {

        public PageType currentType { get; set; }
        public string breakLine { get; } = "\n=======================================================================================================\n";

        public string pageInfo { get; set; } = "";
        public string error { get; set; } = "";
        public string instructions { get; set; } = "";




        public Page(PageType x)
        {
            //Default value
            currentType = x;

        }


        //Main_Menu,
        //Create_NewGame,
        //Create_Character,
        //Load_Game,
        //Paragraph,
        //Paragraph_Combat,
        //Bestiary,
        //ExampleEnum


        //Text to show when transitioning to this page from a different one.
        public void switchPage(PageType x,UI UI)
        {
            switch (x)
            {
                case PageType.Main_Menu:
                    currentType = PageType.Main_Menu;
                    pageInfo = "Welcome to the main menu!";
                    instructions = "Press 1 for new game\n Press 2 to create a new character \n Press 3 to load a game \n Press 4 to Paragraph \n Press 9 for example page";
                    UI.DrawUI(UI, true);

                    break;



                case PageType.Create_NewGame:
                    break;

                case PageType.Create_Character:
                    currentType = PageType.Create_Character;
                    pageInfo = "Welcome to character creation page!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI,true);
                    break;

                case PageType.Load_Game:
                    currentType = PageType.Load_Game;
                    pageInfo = "Welcome to game loading screen!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Paragraph:
                    currentType = PageType.Paragraph;
                    pageInfo = "Welcome to Paragraphs!!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Paragraph_Combat:
                    currentType = PageType.Paragraph_Combat;
                    pageInfo = "Welcome to combat Paragraph!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Bestiary:
                    currentType = PageType.Bestiary;
                    pageInfo = "Welcome to the Bestiary!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.ExampleEnum:
                    currentType = PageType.ExampleEnum;
                    pageInfo = "Welcome to the example page!";
                    instructions = "Press 1 to show example messages!\n Press 2 to go back to main menu!";
                    UI.DrawUI(UI, true);
                    break;
                default:
                    throw new Exception("SwitchPage() was ivoked at Page.Cs with an unhandled page type.Default message won't be assigned.");
                    break;




            }

        }

    }
}
