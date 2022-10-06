using OstreC.Services;
using OstreC;
using OstreC.Interface;
using OstreC.ManageInput;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;


UI UI = new UI();
UI.Page.switchPage(PageType.Main_Menu,UI);
 
 
do
{


     

    UI.checkInput(UI);


} while (UI.exit == false);

