using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Interface
{
    public class CreateNewGameInput : IuiInput
    {

       
        public PageType Type => PageType.Create_NewGame;
        public void checkUserInput(UI UI)
        {
            UI.Page.pageInfo = "Welcome to Game creation";
            UI.Page.instructions = "Type New to create new Game ";

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here




        }

    }
}
