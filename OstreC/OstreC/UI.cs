using OstreC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;




namespace OstreC
{
    public  class UI


    {
        MainMenuInput activePage = new MainMenuInput();
        //ID of active page
       

        //LIST containing  existing menu commands. 
        public static readonly string[] _menuCommands = { "BACK", "MAIN_MENU", "EXIT" };

        public static string breakLine = "\n====================================================================\n";

        //Holds all different methods allowing to draw the UI.
        public List<IuiInterface> pageTypes { get; } = new List<IuiInterface>();

        //Types of pages requiring different input
       


       



        public UI(string descriptionTxT = "Init", int pageNr = 1)
        {


            //pageTypes.Add(new ParagraphInput());
            pageTypes.Add(new MainMenuInput());

        }

        

        public void drawUI(Page page)
        { 
            foreach (var type in pageTypes)
            {
              
                if(type.Type == page.Type) { }

            }

        }








    }

 
}
