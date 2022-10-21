using OstreC.Services;
using OstreC;


//UI.GameSession = new GameSession(new SaveFile(ParagraphType.DescOfStage, 2, "DefaultStory"), new Player(), false); //We need a default value for now. 
//UI instance is the main object storing all variables used later on. Save files, characters, enemies instances.

//Main components Init.
UI UI = new UI(); 
UI.GameSession = new GameSession(null, null, false);

UI.Page.switchPage(PageType.Login, UI);

do
{

    UI.ChooseInputMethod(UI);

} while (UI.Exit == false);
 