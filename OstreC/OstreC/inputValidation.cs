using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC
{
    internal class inputValidation
    {
        public static bool isNumber(string x)
        {
            bool isNr = int.TryParse(x, out int n);
            if (isNr) { return true; }
            return false;


        }

        //Provides input check depending on active page. This way the same input can be entered per page with different results

        public  static void inputCheck(ref Game Game,string input)
        {
 

            switch (Game.activePageNr)
            {
                //Input check for main menu
                case 0:

                    if (Game.isCommand(input.Trim()))
                    {
                        Game.executeCommand(input.Trim());

                    }
                    else if (isNumber(input))
                    {

                        int inputNr = Convert.ToInt32(input);

                        if (inputNr <= Game.maxPagesNr & inputNr >= 0)
                        {
                            Game.activePageNr = inputNr;
                            Game.error = "";

                        }
                        else
                        {
                            Game.error = "The number provided was either too high or too low";

                        }
                    }
                    else
                    {
                        Game.error = "You provided a text. It didn't match a command or a page number to navigate to";

                    }

                    break;
                    //Input check for character creation
                case 1:
                    if (Game.isCommand(input.Trim()))
                    {
                        Game.executeCommand(input.Trim());

                    }
                   

                    break;
                    //Input check for load game screen
                case 2:
                    if (Game.isCommand(input.Trim()))
                    {
                        Game.executeCommand(input.Trim());

                    }
                    Program.startGameSession(ref Game);

                    break;

                case 3:

                    //Input check once the game started
                    if (Game.isCommand(input.Trim()))
                    {
                        Game.executeCommand(input.Trim());

                    }
                    break;
                    //Input check for review screen (required based on project guidelines)
                case 4:
                    if (Game.isCommand(input.Trim()))
                    {
                        Game.executeCommand(input.Trim());

                    }
                    break;

                default:

                    break;

            }



        }
    }
}
