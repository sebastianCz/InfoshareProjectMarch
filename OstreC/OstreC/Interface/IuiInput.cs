using OstreC.Services;
using OstreC;
using OstreC.Interface;
using OstreC.ManageInput;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;




namespace OstreC.Interface
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
        Login
    }

    public interface IuiInput
    {     
        PageType  Type { get; }
        
        //Check User Input depending on currently active page. 
        public void checkUserInput(UI UI);
    }
}

 
 