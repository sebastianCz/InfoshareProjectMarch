namespace OstreC.Services
{
    public class ReaderStories
    {
        public static string ThrowParagraphText(ParagraphType type, Story currentStory, int idParagraph)
        {
            switch (type)
            {
                case ParagraphType.DescOfStage:
                    foreach (DescOfStage descOfStage in currentStory.DescOfStages)
                    {
                        if (idParagraph == descOfStage.IdParagraph) return descOfStage.TextParagraph;
                    }
                    throw new ArgumentException("DescOfStage Paragraph not found");
                case ParagraphType.Fight:
                    foreach (FightParagraph fightParagraph in currentStory.FightParagraphs)
                    {
                        if (idParagraph == fightParagraph.IdParagraph) return fightParagraph.TextParagraph;
                    }
                    throw new ArgumentException("Fight Paragraph not found");
                case ParagraphType.Test:
                    foreach (TestParagraph testParagraph in currentStory.TestParagraphs)
                    {
                        if (idParagraph == testParagraph.IdParagraph) return testParagraph.TextParagraph;
                    }
                    throw new ArgumentException("Test Paragraph not found");
                case ParagraphType.Dialog:
                    foreach (DialogParagraph dialogParagraph in currentStory.DialogParagraphs)
                    {
                        if (idParagraph == dialogParagraph.IdParagraph) return dialogParagraph.TextParagraph;
                    }
                    throw new ArgumentException("Dialog Paragraph not found");
            }
            return "";
        }
        public static string ThrowOptionsText(ParagraphType type, Story currentStory, int idParagraph)
        {
            string options = " Type 'Save' to save your progress!\n";
            int i = 0;
            switch (type)
            {
                case ParagraphType.DescOfStage:
                    foreach (DescOfStage descOfStage in currentStory.DescOfStages)
                    {
                        if (idParagraph == descOfStage.IdParagraph)
                        {
                            foreach(NextParagraph nextParagraph in descOfStage.NextParagraphs)
                            {
                                options += $" Type {i}. ";
                                options += nextParagraph.ChoiceText;
                                options += "\n";
                                i++;
                            }
                            return options;
                        }
                    }
                    throw new ArgumentException("DescOfStage Paragraph not found");
                case ParagraphType.Fight:
                    foreach (FightParagraph fightParagraph in currentStory.FightParagraphs)
                    {
                        if (idParagraph == fightParagraph.IdParagraph)
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
                    }
                    throw new ArgumentException("Fight Paragraph not found");
                case ParagraphType.Test:
                    foreach (TestParagraph testParagraph in currentStory.TestParagraphs)
                    {
                        if (idParagraph == testParagraph.IdParagraph)
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
                    }
                    throw new ArgumentException("Test Paragraph not found");
                case ParagraphType.Dialog:
                    foreach (DialogParagraph dialogParagraph in currentStory.DialogParagraphs)
                    {
                        if (idParagraph == dialogParagraph.IdParagraph)
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
                    }
                    throw new ArgumentException("Dialog Paragraph not found");
            }
            return "";
        }
        public static Paragraph ThrowObjParagraph(ParagraphType type, Story currentStory, int idParagraph)
        {
            switch (type)
            {
                case ParagraphType.DescOfStage:
                    foreach (DescOfStage descOfStage in currentStory.DescOfStages)
                    {
                        if (idParagraph == descOfStage.IdParagraph) return descOfStage;
                    }
                    throw new ArgumentException("DescOfStage Paragraph not found");
                case ParagraphType.Fight:
                    foreach (FightParagraph fightParagraph in currentStory.FightParagraphs)
                    {
                        if (idParagraph == fightParagraph.IdParagraph) return fightParagraph;
                    }
                    throw new ArgumentException("Fight Paragraph not found");
                case ParagraphType.Test:
                    foreach (TestParagraph testParagraph in currentStory.TestParagraphs)
                    {
                        if (idParagraph == testParagraph.IdParagraph) return testParagraph;
                    }
                    throw new ArgumentException("Test Paragraph not found");
                case ParagraphType.Dialog:
                    foreach (DialogParagraph dialogParagraph in currentStory.DialogParagraphs)
                    {
                        if (idParagraph == dialogParagraph.IdParagraph) return dialogParagraph;
                    }
                    throw new ArgumentException("Dialog Paragraph not found");
            }
            return null;
        }
    }
}
