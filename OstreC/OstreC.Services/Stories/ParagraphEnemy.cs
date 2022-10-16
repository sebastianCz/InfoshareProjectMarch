 
namespace OstreC.Services
{
    //Type of paragraph
    public class ParagraphEnemy
    {
        public int AmountOfEnemy { get; }
        public string EnemyName { get; }
        public ParagraphEnemy(int amountOfEnemy, string enemyName)
        {
            AmountOfEnemy = amountOfEnemy;
            EnemyName = enemyName;
        }
    }
}
