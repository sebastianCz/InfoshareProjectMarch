using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;

namespace OstreCWEB.Services.StoryService
{
    public class StoryService
    {
        private static List<Story> _stories =
            new List<Story>
            {
                new Story
                {
                    Id = 1,
                    Name = "One",
                    Description = "Bar",
                    Paragraphs = new List<Paragraph>
                    {
                        new Paragraph
                        {
                            Id= 1,
                            ParagraphType = ParagraphType.Fight,
                            StageDescription = "First paragraph",
                            FightProp = new Data.Repository.StoryModels.Properties.Fight
                            {
                                Id = 1,
                                ParagraphEnemies = new List<EnemyInParagraph>
                                {
                                    new EnemyInParagraph
                                    {
                                        Id = 1,
                                        AmountOfEnemy = 1,
                                        EnemyId = 1
                                    }
                                }
                            },                           
                            DialogProp = null,
                            TestProp = null,
                            ShopkeeperProp = null,
                        },
                        new Paragraph
                        {
                            Id= 2,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "Second paragraph",
                            FightProp = null,
                            DialogProp = null,
                            TestProp = null,
                            ShopkeeperProp = null,
                        },
                        new Paragraph
                        {
                            Id= 3,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "Third paragraph",
                            FightProp = null,
                            DialogProp = null,
                            TestProp = null,
                            ShopkeeperProp = null,
                        }
                    },
                    FirstParagraphId = 3,
                    UserId = 1,
                },
                new Story
                {
                    Id = 2,
                    Name = "Two",
                    Description = "Pab",
                    Paragraphs = new List<Paragraph>
                    {
                        new Paragraph
                        {
                            Id= 1,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "First paragraph",
                            FightProp = null,
                            DialogProp = null,
                            TestProp = null,
                            ShopkeeperProp = null,
                        },
                        new Paragraph
                        {
                            Id= 2,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "Second paragraph",
                            FightProp = null,
                            DialogProp = null,
                            TestProp = null,
                            ShopkeeperProp = null,
                        }
                    },
                    FirstParagraphId = 2,
                    UserId = 1,
                },
                new Story
                {
                    Id = 3,
                    Name = "Three",
                    Description = "Restaurant",
                    Paragraphs = new List<Paragraph>(),
                    FirstParagraphId = 1,
                    UserId = 1,
                }
            };

        public List<Story> GetAll()
        {
            return _stories;
        }

        public Story GetStoryById(int id)
        {
            return _stories.FirstOrDefault(s => s.Id == id);
        }

        public List<Paragraph> GetParagraphsById(int id)
        {
            var story = _stories.FirstOrDefault(s => s.Id == id);
            return story.Paragraphs;
        }

        public Paragraph GetParagraphById(int id)
        {
            return _stories.SelectMany(s => s.Paragraphs).FirstOrDefault(s => s.Id == id);
        }
    }
}
