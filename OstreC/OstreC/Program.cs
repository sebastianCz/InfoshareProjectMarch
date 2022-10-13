using OstreC.Services;
using OstreC;
using OstreC.Interface;
using System.Runtime.CompilerServices;

UI UI = new UI();

UI.Page.switchPage(PageType.Login, UI);

//UI.Page.switchPage(PageType.Main_Menu, UI);

do
{

    UI.checkInput(UI);

} while (UI.exit == false);


var x = JsonFile.DeserializeEnemyList("Enemy");
//sConsole.WriteLine(x.AllEnemies);



//var x = JsonFile.DeserializeEnemyList("Enemy");

//Console.WriteLine(x.Results[0].EnemyActions[0].ActionDescription);

//Console.ReadKey();
