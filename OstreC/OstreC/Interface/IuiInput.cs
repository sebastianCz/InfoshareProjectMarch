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
        Dictionary,
        Story_Bulider,
        Login,
        ManageAccount,
    }

    public interface IuiInput
    {     
        PageType  Type { get; }

        //Check User Input depending on currently active page. 
        public void CheckUserInput(UI UI);
    }
}

 
 