using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OstreC.Interface;
using OstreC.Services.Characters;

namespace OstreC.ManageInput
{
    public class CreateCharacterHelper
    {
        UI UI = new UI();
        CreatePlayer createPlayer = new CreatePlayer();
        ConsoleColor ccWhite = ConsoleColor.White;
        ConsoleColor ccRed = ConsoleColor.Red;
        public void CreateMenu()
        {            
            while (true)
            {
                Console.Clear();
                UI.Page.switchPage(PageType.Create_Character, UI);

                //Utilities.WriteLineColorText("What do you want to do?", ccWhite, consoleClear: true);
                //Console.WriteLine("1. Use already created adventurer\n2. Create your own adventurer\n3. Delete your adventurer\n4. Display statistics\n0. Test functionality");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        CreateDefaultPlayer();
                        break;
                    case 2:
                        CreateCustomPlayer();
                        break;
                    case 3:
                        DeletePlayer();
                        break;
                    case 4:
                        DisplayStatistics();
                        break;
                    case 9:
                        //GenerateAttributePoints();
                        break;
                    case 8:
                        createPlayer.GenerateAttributePoints();
                        //AddAttributePoints(Attributes.Strength);
                        DisplayListAttributes();
                        break;
                    default:
                        break;
                }
            }
            Utilities.PressAnyKey();
        }
        #region
        private void CreateDefaultPlayer()
        {
            if (createPlayer.isPlayerCreated)
            {
                UI.Page.error = "Player already exists. You can have only 1 adventurer";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (!createPlayer.isPlayerCreated)
            {
                UI.Page.pageInfo = "Custom player was created";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();                
            }
            createPlayer.CreateDefaultPlayer();
        }
        private void CreateCustomPlayer()
        {
            Utilities.WriteLineColorText("Tell me your name: ", firstColor: ccWhite);
            //createPlayer.AddName();
            Utilities.WriteLineColorText("Choose your race: ", firstColor: ccWhite);
            //createPlayer.AddRace();
            Utilities.WriteLineColorText("Choose your class: ", firstColor: ccWhite);
            //createPlayer.AddClass();

            createPlayer.GenerateAttributePoints();
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
            Utilities.WriteLineColorText("What's your strength: ", firstColor: ccWhite);
            createPlayer.AddAttributePoints(CreatePlayer.Attributes.Strength);
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
            Utilities.WriteLineColorText("What's your dexterity: ", firstColor: ccWhite);
            createPlayer.AddAttributePoints(CreatePlayer.Attributes.Dexterity);
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
            Utilities.WriteLineColorText("What's your constitution: ", firstColor: ccWhite);
            createPlayer.AddAttributePoints(CreatePlayer.Attributes.Constitution);
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
            Utilities.WriteLineColorText("What's your intelligence: ", firstColor: ccWhite);
            createPlayer.AddAttributePoints(CreatePlayer.Attributes.Intelligence);
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
            Utilities.WriteLineColorText("What's your wisdom: ", firstColor: ccWhite);
            createPlayer.AddAttributePoints(CreatePlayer.Attributes.Wisdom);
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
            Utilities.WriteLineColorText("What's your charisma: ", firstColor: ccWhite);
            createPlayer.AddAttributePoints(CreatePlayer.Attributes.Charisma);
            createPlayer.AddValueToProperties();
        }
        private void DeletePlayer()
        {
            if (!createPlayer.isPlayerCreated)
            {                
                UI.Page.error = "No adventurer to delete!";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (createPlayer.isPlayerCreated)
            {
                Console.WriteLine("Do you really want to delete your adventurer?\n Press Y - yes; Press N - no");
                string input = Utilities.InputDataAsString(Utilities.rgxYN).ToLower();
                if (input == "y")
                {
                    UI.Page.pageInfo = "Adventurer was deleted";
                    UI.DrawUI(UI, false);
                    Utilities.PressAnyKey();
                    createPlayer.isPlayerCreated = false;
                }
                else
                {
                    UI.Page.pageInfo = "Oh, you have changed your mind";
                    UI.DrawUI(UI, false);
                    Utilities.PressAnyKey();
                }
            }
            createPlayer.DeletePlayer();
        }
        private void DisplayStatistics()
        {
            if (!createPlayer.isPlayerCreated)
            {
                UI.Page.error = "No data to display";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            createPlayer.DisplayStatistics();
            Utilities.PressAnyKey();
        }
        private void DisplayListAttributes()
        {
            createPlayer.DisplayListAttributes(createPlayer.attributePoints);
        }
        #endregion
    }
}
