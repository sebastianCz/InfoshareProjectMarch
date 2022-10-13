using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    //Will be used to store values to initialize the game. Should allow to merge Character creation + Paragraph + Menu logic into one. 
    public class GameSession : ProgramSession
    {
        //I belive this one is handled by story. 
        public static SaveFile SaveFile { get; } = new SaveFile(ParagraphType.DescOfStage, 2, "DefaultStory");

        public CurrentPlayer currentPlayer = new CurrentPlayer(); //Inherited by UI in console to update data based on input. 
        //Passed to console to save data for current Player Character


        public void NewGame()
        {


        }

        public void LoadGame()
        {


        }

    }
}
