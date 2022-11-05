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
            JsonFile.SerializedToJson(gameSession.SaveFile, $"UsersFile\\" + currentUser.UserName);
            currentUser.SaveFileExists = true;
            currentUser.UpdateUser(currentUser, "true", 4);
        }

        public static List<Enemy> InitialEnemies(List<ParagraphEnemy> paragraphEnemies)
        {
            var allEnemiesList = JsonFile.DeserializeFile<List<Enemy>>("Enemy");
            var enemies = new List<Enemy>();

            for (int i = 0; i < paragraphEnemies.Count(); i++)
            {
                for (int j = 0; j < paragraphEnemies[i].AmountOfEnemy; j++)
                {
                    enemies.Add(allEnemiesList.First(n => n.Name == paragraphEnemies[i].EnemyName));
                }
            }
            string serializeEnemies = JsonConvert.SerializeObject(enemies); // One reference to parameter in two diffrent enemy
            return JsonConvert.DeserializeObject<List<Enemy>>(serializeEnemies); // Two regerento to parametr in two diffrent enemy
        }
    }
}
