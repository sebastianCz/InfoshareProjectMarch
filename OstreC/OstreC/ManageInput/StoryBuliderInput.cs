using OstreC.Services;

namespace OstreC.ManageInput
{//Creates a Story Object depending on input. Analyzes strings.
    public class StoryBuilderInput : IuiInput
    {
        public PageType Type => PageType.Story_Bulider;
        private static bool HomePage { get; set; } = true; // True - StoryBuilder home page, 
        private static Story CurrentStory { get; set; }
        public void CheckUserInput(UI UI)
        {
            UI.DrawUI(UI, false);
            UI.Page.Error = "";
            string? input = Console.ReadLine()?.ToUpper().Replace(" ", null);

            if (Helpers.IsCommand(input, UI)) ;
            else if (String.Equals(input, "0"))
            {
                Helpers.WriteLineColorText("Are you sure? You go back to menu.\nPress 'Y' - yes or 'N' - no", ConsoleColor.Red);
                if (Helpers.YesOrNoKey()) UI.Page.switchPage(PageType.Main_Menu, UI);
                HomePage = true;
            } // Go back to main menu
            else if (!HomePage && String.Equals(input, "SAVE")) // Save
            {
                string serializedStory = JsonFile.SerializeStory(CurrentStory);
                JsonFile.SerializedToJson(serializedStory, "Stories\\" + CurrentStory.NameOfStory);
                UI.Page.Error = "Story saved!";
            } // Save changed to NameStory.json
            else if (!HomePage && String.Equals(input, "1")) // Go back to story Builder home page
            {
                Helpers.WriteLineColorText("Are you sure? You go back to Story Builder home page.\nPress 'Y' - yes or 'N' - no", ConsoleColor.Red);
                if (Helpers.YesOrNoKey())
                {
                    UI.Page.switchPage(PageType.Story_Bulider, UI);
                    HomePage = true;
                }
            } // Go back to story Builder home page
            else if (HomePage && String.Equals(input, "1")) // New story in Story Builder home page
            {
                do
                {
                    Helpers.WriteLineColorText("\n You chose creat new story!\n Let's start with something easy, enter the name of the story: ", ConsoleColor.Green);

                    string? nameOfStory = Console.ReadLine();
                    Console.WriteLine($"\nThe name of your story is: {nameOfStory}");

                    Helpers.WriteLineColorText("\nDo you approve the name? \nPress 'Y' - yes or 'N' - no", ConsoleColor.Red);
                    if (Helpers.YesOrNoKey())
                    {
                        CurrentStory = new Story(nameOfStory);
                        CurrentStory.DeafaultParagraph();
                        UI.Page.PageInfo = $"You create a {CurrentStory.NameOfStory} story!";
                        UI.Page.Instructions = " Type 0 to go back to the main menu!\n Type 1 to go Story Builder home page!\n Type 'Save' to save changes!\n Type 'New' to create a new paragraph\n Type 'Link' to create a new paragraph link";
                        HomePage = false;
                        break;
                    }
                    UI.DrawUI(UI, false);
                } while (true);
            } // New story in Story Builder home page
            else if (HomePage && String.Equals(input, "2")) // Loade exist story in Story Builder home page
            {
                do
                {
                    Helpers.WriteLineColorText("\n You have chosen to load an existing story to edit it.\n Enter the name of the story: ", ConsoleColor.Green);

                    string? nameOfStory = Console.ReadLine();
                    Console.WriteLine($"\nThe name of your story is: {nameOfStory}");

                    Helpers.WriteLineColorText("\n Do you approve the name? \n Press 'Y' - yes or 'N' - no", ConsoleColor.Red);
                    if (Helpers.YesOrNoKey())
                    {
                        CurrentStory = JsonFile.DeserializeStory(nameOfStory);
                        UI.Page.PageInfo = $"You create a {CurrentStory.NameOfStory} story!";
                        UI.Page.Instructions = " Type 0 to go back to the main menu!\n Type 1 to go Story Builder home page!\n Type 'Save' to save changes!\n Type 'New' to create a new paragraph\n Type 'Link' to create a new paragraph link";
                        HomePage = false;
                        break;
                    }
                    UI.DrawUI(UI, false);
                } while (true);
            } // Loade exist story in Story Builder home page
            else if (!HomePage && String.Equals(input, "NEW"))
            {
                CreatNewParagraph(UI); // Creat new paragraph
                UI.Page.PageInfo = $"You create a {CurrentStory.NameOfStory} story!";
                UI.Page.Instructions = " Type 0 to go back to the main menu!\n Type 1 to go Story Builder home page!\n Type 'Save' to save changes!\n Type 'New' to create a new paragraph\n Type 'Link' to create a new paragraph link";
            }
            else if (!HomePage && String.Equals(input, "LINK"))
            {
                UI.Page.Error = "User input is not handled yet."; // place for method
                UI.Page.PageInfo = $"You create a {CurrentStory.NameOfStory} story!";
                UI.Page.Instructions = " Type 0 to go back to the main menu!\n Type 1 to go Story Builder home page!\n Type 'Save' to save changes!\n Type 'New' to create a new paragraph\n Type 'Link' to create a new paragraph link";
            }
            else
            {
                UI.Page.Error = "You didn't type the correct option";
            }
        }

        private static void CreatNewParagraph(UI UI)
        {
            List<Option> options = new List<Option>
            {
                new Option("DescOfStage Paragraph", () => CreatNewDescOfStageParagraph(UI)),
                new Option("Fight Paragraph", () =>  CreatNewFightParagraph(UI)),
                new Option("Dialog Paragraph", () =>  CreatNewDialogParagraph(UI)),
                new Option("Test Paragraph", () => CreatNewTestParagraph(UI)),
                new Option("Go back!", () => Console.Clear())
            };

            int index = 0;
            WriteOptionsSelect(options, options[index], UI);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteOptionsSelect(options, options[index], UI);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteOptionsSelect(options, options[index], UI);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    break;
                }
            } while (true);
        }

        static void WriteOptionsSelect(List<Option> options, Option selectedOption, UI UI)
        {
            UI.Page.Instructions = "Use keyboard arrows and press ENTER to aprove.";
            UI.DrawUI(UI, true);
            Console.WriteLine("Select the type of paragraph:\n");

            foreach (Option option in options)
            {
                if (option == selectedOption) Console.Write("> ");
                else Console.Write(" ");

                Console.WriteLine(option.Name);
            }
        }
        private static void CreatNewDescOfStageParagraph(UI UI)
        {
            string? textParagraph = AddTextParagraph(UI, "DescOfStage Paragraph");

            DescOfStage newDesc = new DescOfStage(CurrentStory.AmountOfParagrafh, textParagraph);
            newDesc.DefaultChoice();

            CurrentStory.AddNewDescOfStageParagraph(newDesc);      
        }
        private static void CreatNewFightParagraph(UI UI)
        {
            string? textParagraph = AddTextParagraph(UI, "Fight Paragraph");
            string enemyName = AddEnemy(UI);
            int amountOfEnemy = AmountOfEnemy(UI, enemyName);

            FightParagraph newFight = new FightParagraph(CurrentStory.AmountOfParagrafh, textParagraph);
            newFight.DefaultChoice();
            newFight.AddEnemy(amountOfEnemy, enemyName);

            CurrentStory.AddNewFightParagraph(newFight);
        }
        private static void CreatNewDialogParagraph(UI UI)
        {
            string? textParagraph = AddTextParagraph(UI, "Dialog Paragraph");

            DialogParagraph newDialog = new DialogParagraph(CurrentStory.AmountOfParagrafh, textParagraph);
            newDialog.DefaultChoice();

            CurrentStory.AddNewDialogParagraph(newDialog);
        }
        private static void CreatNewTestParagraph(UI UI)
        {
            string? textParagraph = AddTextParagraph(UI, "Test Paragraph");

            TestParagraph newTest = new TestParagraph(CurrentStory.AmountOfParagrafh, textParagraph);
            newTest.DefaultChoice();

            CurrentStory.AddNewTestParagraph(newTest);
        }
        private static string? AddTextParagraph(UI UI, string typeParagraph)
        {
            UI.Page.PageInfo += $"\nYou create an {typeParagraph}.";
            do
            {
                
                UI.Page.Instructions = "Enter text for the paragraph describing the stage.";
                UI.DrawUI(UI, true);

                Console.Write("Entry new text here: ");
                string? inputText = Console.ReadLine();

                Console.WriteLine($"You entered the text of the paragraph: \n{inputText}");

                Helpers.WriteLineColorText("\n Do you accept the text? \n Press 'Y' - yes or 'N' - no\t", ConsoleColor.Red);
                if (Helpers.YesOrNoKey()) return inputText;
            } while (true);
        }
        private static string AddEnemy(UI UI)
        {
            do
            {
                UI.Page.Instructions = "Enter enemy name.";
                UI.DrawUI(UI, true);

                Console.Write("Entry new enemy here: ");
                string inputText = Console.ReadLine();

                Console.WriteLine($"You entered enemy name: \n{inputText}");

                Helpers.WriteLineColorText("\n Do you accept? \n Press 'Y' - yes or 'N' - no\t", ConsoleColor.Red);
                if (Helpers.YesOrNoKey()) return inputText;
            } while (true);
        }
        private static int AmountOfEnemy(UI UI, string enemyName)
        {
            do
            {
                int amountOfEnemy;
                UI.Page.Instructions = $"Enter amount of {enemyName}.";
                UI.DrawUI(UI, true);

                do
                {
                    Console.Write("Entry amount here: ");
                    string? inputText = Console.ReadLine();

                    if (int.TryParse(inputText, out amountOfEnemy))
                    {
                        if (amountOfEnemy > 0 && amountOfEnemy < 11) break;
                        else Console.WriteLine("Entered a value outside the range 1-10.");
                    }
                    else Console.WriteLine("Entered a value is not a number.");
                } while (true);

                Console.WriteLine($"You entered: \n{amountOfEnemy} {enemyName}");

                Helpers.WriteLineColorText("\n Do you accept the amount of enemies?\n Press 'Y' - yes or 'N' - no\t", ConsoleColor.Red);
                if (Helpers.YesOrNoKey()) return amountOfEnemy;
            } while (true);
        }
    }
}