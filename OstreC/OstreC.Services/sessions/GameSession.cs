namespace OstreC.Services
{
    //Will be used to store values once the function start new game or load game is used. Should allow to merge Character creation + Paragraph + Menu logic into one. S
    public class GameSession
    {
        //I belive this one is handled by story. 
        public SaveFile SaveFile { get; set; }  //We need a default save file in current build. 

        public Player CurrentPlayer { get; set; } //Inherited by UI in console to update data based on input.   //Passed to console to save data for current Player Character

        public bool FileLoaded { get; set; } 

        public GameSession() { }
        public GameSession(SaveFile saveFile, Player currentplayer, bool gameLoaded)
        {
            SaveFile = saveFile;
            CurrentPlayer = currentplayer;
            FileLoaded = gameLoaded;
        }
    }
}
