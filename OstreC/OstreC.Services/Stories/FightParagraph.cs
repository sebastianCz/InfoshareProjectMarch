namespace OstreC.Services.Stories
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
        }
    }
}
