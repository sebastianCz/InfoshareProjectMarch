using OstreC.Services;
using OstreC;
using static System.Net.Mime.MediaTypeNames;

 

//Main components Init.
UI UI = new UI();

UI.Page.switchPage(PageType.Login, UI);

do
{
    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);
 