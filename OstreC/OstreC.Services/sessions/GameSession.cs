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
        public  SaveFile SaveFile { get; set; }  //We need a default save file in current build. 

       public CurrentPlayer currentPlayer { get; set; } //Inherited by UI in console to update data based on input.   //Passed to console to save data for current Player Character
         public bool FileLoaded = false;

        
        public GameSession()
        {

        }
        public GameSession(SaveFile saveFile,CurrentPlayer currentplayer,bool gameLoaded)
        {

            
        }

      
        public GameSession NewGame(string storyName)
        {
            var session = new GameSession();
            session.FileLoaded = true; //Sets to true and loads "default" instance of save file without deserializing. There's nothing to deserialize. 
            session.SaveFile = new SaveFile(0,2, storyName);//Default values
            return session;
        }

        public GameSession loadSave(string userName)
        {
            var session = new GameSession();
            session.FileLoaded = true;
            session.SaveFile = JsonFile.DeserializeSaveFile($"UsersFile\\" + userName);
            return session;
        }

    }
}
