using OstreC.Services;
using OstreC;

//UI instance is the main object storing all variables used later on. Save files, characters, enemies instances.
UI UI = new UI();
UI.GameSession = new GameSession(new SaveFile(ParagraphType.DescOfStage, 2, "DefaultStory"), new Player(), false); //We need a default value for now. 
// Default values. UI.CurrentUser


UI.Page.switchPage(PageType.Login, UI);

do
{

    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);

 