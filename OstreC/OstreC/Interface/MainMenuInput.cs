using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Interface
{
    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;


        public void checkUserInput(UI UI)
        {


            UI.Page.pageInfo = "Welcome to Main Menu!";
            UI.Page.instructions = "Press 1 to create New Character \n Press 2 to Delete  \n Press 3 to Edit character \n ";
            var input = Console.ReadLine();


            if (Helpers.isCommand(input, UI))
            {

                Helpers.HandleCommand(input, UI);

            }

           
            if (Helpers.isNumber(input))
            {

                if (input == "1")
                {
                    UI.Page.currentType = PageType.Create_NewGame;
                    UI.Page.pageInfo = "Welcome to Game creation";
                    UI.Page.instructions = "Type New to create new Game ";
                }
                else if (input == "2")
                {
                    UI.Page.currentType = PageType.Create_Character;
                    UI.Page.pageInfo = "Welcome to Character Creation";
                    UI.Page.instructions = "Press 1 to create New Character \n Press 2 to Delete  \n Press 3 to Edit character \n ";
                }
                else if (input == "3")
                {

                    UI.Page.currentType = PageType.Load_Game;
                }
  
                else if (input == "4")
                {
                    UI.Page.currentType = PageType.Bestiary;
                    
                }else if(input == "9")
                {
                    UI.Page.currentType = PageType.ExampleEnum;
                    UI.Page.pageInfo = "Welcome to Example page!";
                    UI.Page.instructions = "Press 1 to create New Character \n Pres 2 to go back to main menu.  ";

                }
                else
                {
                    UI.Page.error = "You didn't provide a correct number";

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
}
