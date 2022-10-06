using OstreC.Services;
using OstreC;
using OstreC.Interface;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

namespace OstreC.ManageInput
{
    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;
         

        public void checkUserInput(UI UI)
        {
            
          
                       var input = Console.ReadLine();
 
            if (Helpers.isCommand(input, UI))
            {

                Helpers.HandleCommand(input, UI);

            }

           
            if (Helpers.isNumber(input))
            {

                if (input == "1")
                {
                    
                    UI.Page.switchPage(PageType.Create_Character,UI  );
                }
                else if (input == "2")
                {
                    UI.Page.switchPage(PageType.Create_NewGame, UI  );
                }
                else if (input == "3")
                {

                    UI.Page.switchPage(PageType.Load_Game, UI   );
                }
  
                else if (input == "4")
                {
                    UI.Page.switchPage(PageType.Paragraph, UI  );

                }
                else if(input == "9")
                {
                    UI.Page.switchPage(PageType.ExampleEnum, UI  );


                }
                else
                {
                    UI.Page.error = "You didn't provide a correct number";
                    UI.DrawUI(UI,false);
                }

            }
            else
            {
                UI.Page.error = "You didn't provide a correct number";
                UI.DrawUI(UI, false);
            }


//            //ENUM iteration -> So options can be created dynamically without having to update the entire logic each time. 
//            //foreach (int i  in Enum.GetValues(typeof(PageType)))
//            //{
//            //    pageInfo += ($"{Enum.GetName(typeof(PageType), i)}");


//            //}

// 

}



    }
}
