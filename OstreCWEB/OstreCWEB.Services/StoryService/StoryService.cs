using OstreCWEB.Data.Enums;
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
                    Name = "Lost Mine Of Phandelver",
                    Description = "Lost Mine of Phandelver is an adventur is set a short distance from the city of Neverwinter in the Sword Coast region of the Forgotten Realms setting.",
                    Paragraphs = new List<Paragraph>
                    {
                        new Paragraph
                        {
                            Id= 0,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "You die, load the game or start over!"
                        },
                        new Paragraph
                        {
                            Id= 1,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "In the city of Neverwinter, a dwarf named Gundren Rockseeker asked you to bring a wagon load of provisions to the rough-and-tumble settlement of Phandalin, a couple of days' travel southeast of the city. Gundren was clearly excited and more than a little secretive about his reasons for the trip, saying only that he and his brothers had found \"something big\", and that he'd pay you ten gold pieces each for escorting his supplies safely to Barthen's Provisions, a trading post in Phandalin. He then set out ahead of you on horse, along with a warrior escort named Sildar Haliwinter, claiming he needed to arrive early to \"take care of business.\" You've spent the last few days following the High Road south from Neverwinter, and you've just recently veered east along the Triboar Trail. You've encountered no trouble so far, but this territory can be dangerous. Bandits and outlaws have been known to lurk along the trail.",
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 1,
                                    ChoiceText = "What's on the cart?",
                                    NextParagraphId = 2
                                },
                                new NextParagraph
                                {
                                    Id = 2,
                                    ChoiceText = "Next",
                                    NextParagraphId = 3
                                },
                            }
                        },
                        new Paragraph
                        {
                            Id= 2,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "The wagon is packed full of an assortment of mining supplies and food. This includes a dozen sacks of flour, several casks ofsalted pork, two kegs ofstrong ale, shovels, picks, and crowbars (about a dozen each), and five lanterns with a small barrel of oil (about fiftyflasks in volume). The total value of the cargo is 100 gp.",
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 3,
                                    ChoiceText = "Next",
                                    NextParagraphId = 3
                                }
                            }
                        },                        
                        new Paragraph
                        {
                            Id= 3,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "You've been on the Triboar Trail for about half a day. As you come around a bend, you spot two dead horses sprawled about fifty feet ahead of you, blocking the path. Each has several black-feathered arrows sticking out of it. The woods press close to the trail here, with a steep embankment and dense thickets on either side.",
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 4,
                                    ChoiceText = "Look around",
                                    NextParagraphId = 4
                                },
                                new NextParagraph
                                {
                                    Id = 5,
                                    ChoiceText = "Come closer",
                                    NextParagraphId = 5
                                },
                            }
                        },                        
                        new Paragraph
                        {
                            Id= 4,
                            ParagraphType = ParagraphType.Test,
                            StageDescription = "Perception test to see goblins",
                            TestProp = new TestProp
                            {
                                Id = 1,
                                Skill = Skills.Perception,
                                TestDifficulty = TestDifficulty.Easy
                            },
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 6,
                                    ChoiceText = "Failure",
                                    NextParagraphId = 5
                                },
                                new NextParagraph
                                {
                                    Id = 7,
                                    ChoiceText = "Success",
                                    NextParagraphId = 6
                                },
                            }
                        },
                        new Paragraph
                        {
                            Id= 5,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "The horses as belonging to Gundren Rockseeker and Sildar Hallwinter. They've been dead about a day, and it's clear that arrows killed the horses.",
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 8,
                                    ChoiceText = "Get closer to the dead horses",
                                    NextParagraphId = 7
                                }
                            }
                        },
                        new Paragraph
                        {
                            Id= 6,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "Two goblins are hiding in the woods, one on each side of the road.",
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 9,
                                    ChoiceText = "Get closer to the dead horses",
                                    NextParagraphId = 7
                                },
                                new NextParagraph
                                {
                                    Id = 10,
                                    ChoiceText = "Attack goblins",
                                    NextParagraphId = 8
                                }
                            }
                        },
                        new Paragraph
                        {
                            Id= 7,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "The saddlebags have been looted. Nearby lies an empty 1 leather map case.",
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 11,
                                    ChoiceText = "Next",
                                    NextParagraphId = 8
                                },
                            }                       
                        },
                        new Paragraph
                        {
                            Id= 8,
                            ParagraphType = ParagraphType.Fight,
                            StageDescription = "Fight with 2 goblin",
                            FightProp = new FightProp
                            {
                                Id = 1,
                                ParagraphEnemies = new List<EnemyInParagraph>
                                {
                                    new EnemyInParagraph
                                    {
                                        Id = 1,
                                        AmountOfEnemy = 2,
                                        EnemyId = 1,
                                        EnemyName = "Goblin"
                                    }
                                }
                            },
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 12,
                                    ChoiceText = "Defeat!",
                                    NextParagraphId = 0
                                },
                                new NextParagraph
                                {
                                    Id = 13,
                                    ChoiceText = "Victory!",
                                    NextParagraphId = 9
                                },
                            }
                        },
                        new Paragraph
                        {
                            Id= 9,
                            ParagraphType = ParagraphType.DescOfStage,
                            StageDescription = "You are looking at two dead goblins.",                            
                            Choices = new List<NextParagraph>
                            {
                                new NextParagraph
                                {
                                    Id = 14,
                                    ChoiceText = "Nothing else, kill your hero!",
                                    NextParagraphId = 0
                                }
                            }
                        }
                    },
                    FirstParagraphId = 1,
                    UserId = 0,
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

        public List<Paragraph> GetPreviousParagraphsById(int id, int idStory)
        {
            var story = _stories.FirstOrDefault(p => p.Id == idStory);
            var paragraphs = story.Paragraphs.Where(s => s.Choices.Any(c => c.NextParagraphId == id)).ToList();
            return paragraphs;
        }
    }
}
