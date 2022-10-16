using OstreC.Services;
using OstreC;
 



namespace OstreC
{

    public enum PageType
    {
        Main_Menu,
        Create_NewGame,
        Create_Character,
        Load_Game,
        Paragraph,
        Paragraph_Combat,
        Bestiary,
        ExampleEnum,
        Story_Bulider,
        Login,
        ManageAccount,
        StartGame
    }

    public interface IuiInput
    {     
        PageType  Type { get; }
        
        //Check User Input depending on currently active page. 
        public void CheckUserInput(UI UI);
    }
}

 
 