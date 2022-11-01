using OstreC;

//Main components Init.
UI UI = new UI();

UI.Page.switchPage(PageType.Create_Character, UI); //page type login

do
{
    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);