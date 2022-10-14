using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
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
