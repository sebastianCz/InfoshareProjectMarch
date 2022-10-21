using OstreC.Services;
using OstreC;
using static System.Net.Mime.MediaTypeNames;

 

//Main components Init.
UI UI = new UI();
UI.CurrentUser = new CurrentUser();

UI.Page.switchPage(PageType.Main_Menu, UI);

do
{
    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);
 