namespace OstreCWEB.Data.Repository.StoryModels.Properties
{
    public class EnemyInParagraph
    {
        // General
        public int Id { get; set; }

        public int AmountOfEnemy { get; set;  }
        public int EnemyId { get; set;  }
        public string EnemyName { get; set; }

        // Db relations properties
        public int FightId { get; set; }
        public FightProp Fight { get; set; }
    }
}
