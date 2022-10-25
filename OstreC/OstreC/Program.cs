using OstreC.Services;
using OstreC;
using static System.Net.Mime.MediaTypeNames;

 

//Main components Init.
UI UI = new UI();
UI.CurrentUser = new CurrentUser(); //To delete once branch is ready for merge. 

UI.Page.switchPage(PageType.Main_Menu, UI);

do
{
    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);
 