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
            string serializedSaveFile = JsonFile.SerializeSaveFile(gameSession.SaveFile);
            JsonFile.SerializedToJson(serializedSaveFile, $"UsersFile\\" + currentUser.UserName);
            currentUser.SaveFileExists = true;
            currentUser.UpdateUser(currentUser, "true", 4);
        }
        public static string SolveFight(List<ParagraphEnemy> paragraphEnemies) // result - 1 - lose; 2 - win;
        {
            return "1"; // lose
            return "2"; // win
        }
        public static string SolveTest() // result - 1 - lose; 2 - win;
        {
            return "1"; // lose
            return "2"; // win
        }
    }
}
