using OstreC;

//Main components Init.
UI UI = new UI();

UI.Page.SwitchPage(PageType.Login, UI);

do
{
    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);