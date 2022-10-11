using OstreC.Services;
using OstreC;
using OstreC.Interface;
  
UI UI = new UI();
UI.currentUser.Email = "sebastianczarnowski95@gmail.com";
//UI.Page.switchPage(PageType.Login, UI);

UI.Page.switchPage(PageType.Main_Menu, UI);

do
{
   
    UI.checkInput(UI);
   
} while (UI.exit == false);