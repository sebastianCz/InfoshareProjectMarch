using Newtonsoft.Json;
using System.Collections.Generic;

namespace OstreC.Services
{
    public class Story
    {
        public string NameOfStory { get; private set; }
        public int AmountOfParagrafh { get { return Paragraphs.Count(); } }

        [JsonIgnore]
        public List<Paragraph> Paragraphs { get; private set; } = new List<Paragraph>();

        public List<FightParagraph> FightParagraphs { get; } = new List<FightParagraph>();
        public List<TestParagraph> TestParagraphs { get; } = new List<TestParagraph>();
        public List<DialogParagraph> DialogParagraphs { get; } = new List<DialogParagraph>();
        public List<DescOfStage> DescOfStages { get; } = new List<DescOfStage>();

        public Story(string nameOfStory)
        {
            NameOfStory = nameOfStory;
        }

        public void DeafaultParagraph()
        {
            DescOfStage menu = new DescOfStage(0, "menu");
            DescOfStage dead = new DescOfStage(1, "dead");

            DescOfStages.Add(menu);
            Paragraphs.Add(menu);
            DescOfStages.Add(dead);
            Paragraphs.Add(dead);
        }

        public void AddNewDescOfStageParagraph(DescOfStage newDescOfStage)
        {
            Paragraphs.Add(newDescOfStage);
            DescOfStages.Add(newDescOfStage);
        }
        public void AddNewFightParagraph(FightParagraph newFightParagraph)
        {
            Paragraphs.Add(newFightParagraph);
            FightParagraphs.Add(newFightParagraph);
        }
        public void AddNewDialogParagraph(DialogParagraph newDialogParagraph)
        {
            Paragraphs.Add(newDialogParagraph);
            DialogParagraphs.Add(newDialogParagraph);
        }

        public void AddNewTestParagraph(TestParagraph newTestParagraph)
        {
            Paragraphs.Add(newTestParagraph);
            TestParagraphs.Add(newTestParagraph);
        }

        public void AddAllParagraph()
        {
            
            foreach (FightParagraph x in FightParagraphs)
            {
                Paragraphs.Add(x);
            }
            foreach (DescOfStage x in DescOfStages)
            {
                Paragraphs.Add(x);
            }
            foreach (DialogParagraph x in DialogParagraphs)
            {
                Paragraphs.Add(x);
            }
            foreach (TestParagraph x in TestParagraphs)
            {
                Paragraphs.Add(x);
            }
            Paragraphs = Paragraphs.OrderBy(o => o.IdParagraph).ToList();
        }
    }
}
