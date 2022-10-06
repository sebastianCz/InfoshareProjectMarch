using OstreC.Services;
using OstreC;
using OstreC.Interface;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.ManageInput
{
    public class Create_Character : IuiInput
    {
        public PageType Type => PageType.Create_Character;
        public void checkUserInput(UI UI)
        {
            Console.WriteLine("Pokaz opjce cos tam");
            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }



            //Your code goes here
            if (input == "jeden" ) {

                UI.Page.error = "brawo";
                UI.DrawUI(UI, false);
            }
            else
            {
                UI.Page.error = "wpisales bzdury";
                UI.DrawUI(UI, false);

            }



        }

    }
}
