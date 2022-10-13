using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    //Will be used to store values to initialize the game. Should allow to merge Character creation + Paragraph + Menu logic into one. 
    internal class GameSession : ProgramSession
    {
        //I belive this one is handled by story. 
        public int ActiveParagraph { get; set; }

        public CurrentPlayer currentPlayer = new CurrentPlayer(); //Inherited by UI in console to update data based on input. 
        //Passed to console to save data for current Player Character

        public Story activeStory { get; set; } //I'm not defining it yet. I'm not sure bsaed on what we initialise that part of the object. 

        public void NewGame()
        {


        }

        public void LoadGame()
        {


        }

    }
}
