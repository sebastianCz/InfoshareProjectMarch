using Newtonsoft.Json;

namespace OstreC.Services
{
    //Contains method to loop through paragraphs in a given story and show their content.   
    public static class ReaderStories
    {
        public static string ThrowParagraphText(ParagraphType type, Story currentStory, int idParagraph)
        {
            switch (type)
            {
                case ParagraphType.DescOfStage:
                    DescOfStage? descOfStage = currentStory.DescOfStages.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (descOfStage != null) return descOfStage.TextParagraph;
                    throw new Exception("DescOfStage Paragraph not found");

                case ParagraphType.Fight:
                    FightParagraph? fightParagraph = currentStory.FightParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (fightParagraph != null) return fightParagraph.TextParagraph;
                    throw new Exception("Fight Paragraph not found");

                case ParagraphType.Test:
                    TestParagraph? testParagraph = currentStory.TestParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (testParagraph != null) return testParagraph.TextParagraph;
                    throw new Exception("Test Paragraph not found");

                case ParagraphType.Dialog:
                    DialogParagraph? dialogParagraph = currentStory.DialogParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (dialogParagraph != null) return dialogParagraph.TextParagraph;
                    throw new Exception("Dialog Paragraph not found");
                default:
                    throw new Exception("Unknow ParagraphType");
            }
        }
        public static string ThrowOptionsText(ParagraphType type, Story currentStory, int idParagraph)
        {
            string options = " Type 'Save' to save your progress!\n";
            int i = 0;
            switch (type)
            {
                case ParagraphType.DescOfStage:
                    DescOfStage? descOfStage = currentStory.DescOfStages.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (descOfStage != null)
                    {
                        foreach (NextParagraph nextParagraph in descOfStage.NextParagraphs)
                        {
                            options += $" Type {i}. ";
                            options += nextParagraph.ChoiceText;
                            options += "\n";
                            i++;
                        }
                        return options;
                    }
                    throw new Exception("DescOfStage Paragraph not found");

                case ParagraphType.Fight:
                    FightParagraph? fightParagraph = currentStory.FightParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (fightParagraph != null)
                    {
                        foreach (NextParagraph nextParagraph in fightParagraph.NextParagraphs)
                        {
                            options += $" Type {i}. ";
                            options += nextParagraph.ChoiceText;
                            options += "\n";
                            i++;
                        }
                        return options;
                    }
                    throw new Exception("Fight Paragraph not found");

                case ParagraphType.Test:
                    TestParagraph? testParagraph = currentStory.TestParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (testParagraph != null)
                    {
                        foreach (NextParagraph nextParagraph in testParagraph.NextParagraphs)
                        {
                            options += $" Type {i}. ";
                            options += nextParagraph.ChoiceText;
                            options += "\n";
                            i++;
                        }
                        return options;
                    }
                    throw new Exception("Test Paragraph not found");

                case ParagraphType.Dialog:
                    DialogParagraph? dialogParagraph = currentStory.DialogParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (dialogParagraph != null)
                    {
                        foreach (NextParagraph nextParagraph in dialogParagraph.NextParagraphs)
                        {
                            options += $" Type {i}. ";
                            options += nextParagraph.ChoiceText;
                            options += "\n";
                            i++;
                        }
                        return options;
                    }
                    throw new Exception("Dialog Paragraph not found");
                default:
                    throw new Exception("Unknow ParagraphType");
            }
        }
        public static Paragraph ThrowObjParagraph(ParagraphType type, Story currentStory, int idParagraph)
        {
            switch (type)
            {
                case ParagraphType.DescOfStage:
                    DescOfStage? descOfStage = currentStory.DescOfStages.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (descOfStage != null) return descOfStage;
                    throw new Exception("DescOfStage Paragraph not found");

                case ParagraphType.Fight:
                    FightParagraph? fightParagraph = currentStory.FightParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (fightParagraph != null) return fightParagraph;
                    throw new Exception("Fight Paragraph not found");

                case ParagraphType.Test:
                    TestParagraph? testParagraph = currentStory.TestParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (testParagraph != null) return testParagraph;
                    throw new Exception("Test Paragraph not found");

                case ParagraphType.Dialog:
                    DialogParagraph? dialogParagraph = currentStory.DialogParagraphs.FirstOrDefault(p => p.IdParagraph == idParagraph);
                    if (dialogParagraph != null) return dialogParagraph;
                    throw new Exception("Dialog Paragraph not found");
                default:
                    throw new Exception("Unknow ParagraphType");
            }
        }
        public static void SaveProgress(CurrentUser currentUser, GameSession gameSession)
        {
            gameSession.SaveFile.HealthPoints =gameSession.CurrentPlayer.HealthPoints;//Saves only healthpoints instead of the entire character in the save file... 
            gameSession.SaveFile.CharacterName = gameSession.CurrentPlayer.Name;
            string serializedSaveFile = JsonFile.SerializeSaveFile(gameSession.SaveFile);
            JsonFile.SerializedToJson(serializedSaveFile, $"UsersFile\\" + currentUser.UserName);
            currentUser.SaveFileExists = true;
            currentUser.UpdateUser(currentUser, "true", 4);
        }
        public static string SolveFight(AllEnemyList paragraphEnemies, Player currentPlayer) // result - 1 - lose; 2 - win;
        {
            do
            {
                Console.WriteLine($"HP1: {paragraphEnemies.Results[0].Name} {paragraphEnemies.Results[0].HealthPoints}");
                Console.WriteLine($"HP2: {paragraphEnemies.Results[1].Name} {paragraphEnemies.Results[1].HealthPoints}");
                Console.WriteLine($"HP3: {paragraphEnemies.Results[2].Name} {paragraphEnemies.Results[2].HealthPoints}\n");
                paragraphEnemies.Results[0].HealthPoints -= 10;
                paragraphEnemies.Results[1].HealthPoints -= 10;
                paragraphEnemies.Results[2].HealthPoints -= 10;
                Console.WriteLine($"HP1: {paragraphEnemies.Results[0].Name} {paragraphEnemies.Results[0].HealthPoints}");
                Console.WriteLine($"HP2: {paragraphEnemies.Results[1].Name} {paragraphEnemies.Results[1].HealthPoints}");
                Console.WriteLine($"HP3: {paragraphEnemies.Results[2].Name} {paragraphEnemies.Results[2].HealthPoints}\n");

                if (paragraphEnemies.Results[2].HealthPoints <= 0) paragraphEnemies.Results.Remove(paragraphEnemies.Results[2]);
                if (paragraphEnemies.Results[1].HealthPoints <= 0) paragraphEnemies.Results.Remove(paragraphEnemies.Results[1]);
                if (paragraphEnemies.Results[0].HealthPoints <= 0) paragraphEnemies.Results.Remove(paragraphEnemies.Results[0]);

                if (paragraphEnemies.Results.Count == 0) return "2"; // win
                if (currentPlayer.HealthPoints <= 0) return "1"; // lose
            } while (true);
        }

        public static AllEnemyList InitialEnemies(List<ParagraphEnemy> paragraphEnemies)
        {
            AllEnemyList allEnemiesList = JsonFile.DeserializeEnemyList("Enemy");

            AllEnemyList enemies = new AllEnemyList();

            for (int i = 0; i < paragraphEnemies.Count(); i++)
            {
                for (int j = 0; j < paragraphEnemies[i].AmountOfEnemy; j++)
                {
                    enemies.Results.Add(allEnemiesList.Results.First(n => n.Name == paragraphEnemies[i].EnemyName));
                }
            }
            string serializeEnemies = JsonConvert.SerializeObject(enemies); // One reference to parameter in two diffrent enemy
            enemies = JsonConvert.DeserializeObject<AllEnemyList>(serializeEnemies); // Two regerento to parametr in two diffrent enemy

            return enemies;
        }
    }
}
