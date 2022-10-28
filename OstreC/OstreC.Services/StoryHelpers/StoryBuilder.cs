using System.Collections.Generic;

namespace OstreC.Services
{
    public class StoryBuilder
    {
        public static Paragraph[] SelectList(Story editStory, ParagraphType paragraphType)
        {

            switch (paragraphType)
            {
                case ParagraphType.DescOfStage:
                    var listDesc = editStory.DescOfStages.Select(d =>
                    new DescOfStage(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listDesc;

                case ParagraphType.Fight:
                    var listFight = editStory.FightParagraphs.Select(d =>
                    new FightParagraph(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listFight;

                case ParagraphType.Test:
                    var listTest = editStory.TestParagraphs.Select(d =>
                    new TestParagraph(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listTest;

                case ParagraphType.Dialog:
                    var listDialog = editStory.DialogParagraphs.Select(d =>
                    new DialogParagraph(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listDialog;

                default:
                    throw new Exception("Unknow ParagraphType");
            }
        }
        public static void AddNextParagraphToList(Story editStory, ParagraphType firstParagraphType, int firstParagraphID, string textOfOption, ParagraphType secondParagraphType, int secondParagraphID)
        {
            switch (firstParagraphType)
            {
                case ParagraphType.DescOfStage:
                    DescOfStage? descOfStage = editStory.DescOfStages.FirstOrDefault(p => p.IdParagraph == firstParagraphID);
                    descOfStage.AddNewChoice(new NextParagraph(secondParagraphType, textOfOption, secondParagraphID));
                    break;

                case ParagraphType.Fight:
                    FightParagraph? fightParagraph = editStory.FightParagraphs.FirstOrDefault(p => p.IdParagraph == firstParagraphID);
                    fightParagraph.AddNewChoice(new NextParagraph(secondParagraphType, textOfOption, secondParagraphID));
                    break;

                case ParagraphType.Test:
                    TestParagraph? testParagraph = editStory.TestParagraphs.FirstOrDefault(p => p.IdParagraph == firstParagraphID);
                    testParagraph.AddNewChoice(new NextParagraph(secondParagraphType, textOfOption, secondParagraphID));
                    break;

                case ParagraphType.Dialog:
                    DialogParagraph? dialogParagraph = editStory.DialogParagraphs.FirstOrDefault(p => p.IdParagraph == firstParagraphID);
                    dialogParagraph.AddNewChoice(new NextParagraph(secondParagraphType, textOfOption, secondParagraphID));
                    break;
                default:
                    throw new Exception("Unknow ParagraphType");
            }
        }
    }
}