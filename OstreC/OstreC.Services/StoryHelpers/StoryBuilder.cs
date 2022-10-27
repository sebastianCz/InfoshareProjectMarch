using System.Collections.Generic;

namespace OstreC.Services
{
    public class StoryBuilder
    {
        public static Paragraph[] SelectList(Story currentStory, ParagraphType paragraphType)
        {

            switch (paragraphType)
            {
                case ParagraphType.DescOfStage:
                    var listDesc = currentStory.DescOfStages.Select(d =>
                    new DescOfStage(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listDesc;

                case ParagraphType.Fight:
                    var listFight = currentStory.FightParagraphs.Select(d =>
                    new FightParagraph(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listFight;

                case ParagraphType.Test:
                    var listTest = currentStory.TestParagraphs.Select(d =>
                    new TestParagraph(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listTest;

                case ParagraphType.Dialog:
                    var listDialog = currentStory.DialogParagraphs.Select(d =>
                    new DialogParagraph(d.IdParagraph, d.TextParagraph)
                    {
                        NextParagraphs = d.NextParagraphs
                    }).ToArray();
                    return listDialog;

                default:
                    throw new Exception("Unknow ParagraphType");
            }
        }
    }
}