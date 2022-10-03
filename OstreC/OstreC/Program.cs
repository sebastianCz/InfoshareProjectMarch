using OstreC.Services;
using OstreC;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using OstreC.Interface;

UI UI = new UI();


UI.Page.pageInfo = "Welcome to main menu";
UI.Page.instructions = "Press 1 to create New Game \n Press 2 to Create new Character \n Press 3 to Load game \n Press 4 to view Bestiary";
do
{
    Console.Clear();

    //Header depending on page type. Defined within the method.
    UI.DrawHeader(UI);

    //Only existing draw template for now. Should be enought for most applications apart from combat + enventually bestiary(Bestiary could use some table drawing pluggins theoratically). 
 
    UI.DrawGenericPage(UI);


    //set below variables to empty strings for next itteration.
    //UI.Page.pageInfo;
    //UI.Page.error;
    //UI.Page.instructions;
    
    UI.clearData(UI);

    //Prompts a console.readline() and compares input. You can set readline to readkey instead. 
    //If input is invalid set UI.Page.Error  to desired error msg and leave function. 

    //    If valid do what you need to. Create a character object , create a new game file, load paragraph to display. 

    UI.checkInput(UI);


} while (UI.exit == false);


 