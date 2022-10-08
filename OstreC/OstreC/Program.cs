using OstreC.Services;
using OstreC;
using OstreC.Interface;




UI UI = new UI();
UI.Page.switchPage(PageType.Login, UI);

//UI.Page.switchPage(PageType.Main_Menu, UI);

do
{

    UI.checkInput(UI);

} while (UI.exit == false);











