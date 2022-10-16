

namespace OstreC.Services
{
    //Type of paragraph
    public class FightParagraph : Paragraph
    {
        public List<ParagraphEnemy> ParagraphEnemies { get; } = new List<ParagraphEnemy>();
        public override ParagraphType ParagraphType => ParagraphType.Fight;
        public FightParagraph(int idParagraph, string? textParagraph = "") 
            : base(idParagraph, textParagraph)
        {
        }
        public void AddEnemy(int amountOfEnemy, string enemyName)
        {
            ParagraphEnemies.Add(new ParagraphEnemy(amountOfEnemy, enemyName));
        }
        public void DefaultChoice()
        {
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Go back to menu!", 0));
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Defeat!", 1));
        }
        public void AddNewChoice(NextParagraph newChioce)
        {
            NextParagraphs.Add(newChioce);
        }
    }
}
