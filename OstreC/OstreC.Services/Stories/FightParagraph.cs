namespace OstreC.Services
{
    public class FightParagraph : Paragraph
    {
        public int AmountOfEnemy { get; }
        public string EnemyName { get; }
        public override ParagraphType ParagraphType => ParagraphType.Fight;
        public FightParagraph(int idParagraph, string textParagraph, int amountOfEnemy, string enemyName) 
            : base(idParagraph, textParagraph)
        {
            AmountOfEnemy = amountOfEnemy;
            EnemyName = enemyName;

            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Go back to menu!", 0));
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Defeat!", 1));
        }
    }
}
