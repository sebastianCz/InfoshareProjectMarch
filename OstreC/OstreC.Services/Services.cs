using OstreC.Database;
using OstreC.Services.Stories;

namespace OstreC.Services
{
    public class Services
    {
        public static Paragraph NewParagraph(int idChoice, int idParagraph, string text)
        {
            switch (idChoice)
            {
                case 1:
                    return new DescOfStage(idParagraph, text);
                case 2:
                    return new DialogParagraph(idParagraph, text);
                case 3:
                    return new FightParagraph(idParagraph, text);
                case 4:
                    return new TestParagraph(idParagraph, text);
                default:
                    throw new ArgumentException("Incorrect paragraph type selection");
            }
        }






    }
}