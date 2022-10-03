using OstreC.Services;
using OstreC;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace OstreC
{
    public class UI


    {
        public bool exit { get; set; } = false;
        public Page Page = new Page(PageType.Main_Menu);
        //ID of active page


        //LIST containing  existing menu commands. 
        public static readonly string[] _menuCommands = { "BACK", "MAIN_MENU", "EXIT" };

        //Holds all different methods allowing to draw the UI.
        public List<IuiInput> pageTypes { get; } = new List<IuiInput>();

        //Types of pages requiring different input







        public UI(string descriptionTxT = "Init", int pageNr = 1)
        {


            //pageTypes.Add(new ParagraphInput());
            pageTypes.Add(new MainMenuInput());
            pageTypes.Add(new CreateNewGameInput());
            pageTypes.Add(new Create_Character());
            pageTypes.Add(new Load_Game());
            pageTypes.Add(new Paragraph());
            pageTypes.Add(new Bestiary());
        }



        public void checkInput(UI UI)
        {
            foreach (var test in pageTypes)
            {

                //Compares activepage.currentType values  (Paragraph_Dialogue for instance) with " type" param of all classes implementing IuiInterface. 

                if (test.Type == UI.Page.currentType)
                { 
                    test.checkUserInput(UI); 
                }else
                {
                    Console.WriteLine("Didn't find the page" +test.Type +"  uivalue: " +UI.Page.currentType);
                }

            }
        }


            public void Draw()
            {
                Console.WriteLine("draw invoked");


            }









        }


    }
 



