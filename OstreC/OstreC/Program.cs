using OstreC.Services;
using OstreC;
using OstreC.Interface;
using System.Runtime.CompilerServices;

UI UI = new UI();
UI.GameSession = new GameSession(new SaveFile(ParagraphType.DescOfStage, 2, "DefaultStory"), new CurrentPlayer(), false); //We need a default value for now. 

S


//UI.Page.switchPage(PageType.Main_Menu, UI);
UI.Page.switchPage(PageType.Login, UI);

do
{

    UI.checkInput(UI);

} while (UI.exit == false);


var x = JsonFile.DeserializeEnemyList("Enemy");
//sConsole.WriteLine(x.AllEnemies);



//var x = JsonFile.DeserializeEnemyList("Enemy");

//Console.WriteLine(x.Results[0].EnemyActions[0].ActionDescription);

//Console.ReadKey();
