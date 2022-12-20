﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Enums;

namespace OstreCWEB.Data.InitialData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OstreCWebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OstreCWebContext>>()))
            {
                InitializeStories(context);
                InitializeParagraphs(context);
                InitializeChoices(context);
                InitializeFightProps(context);
                InitializeEnemyInParagraphs(context);
                InitializeTestProps(context);

                context.SaveChanges();
            }
        }

        private static void InitializeStories(OstreCWebContext context)
        {
            if (context.Stories.Any())
            {
                return;   // DB has been seeded
            }

            context.Stories.AddRange(
            new List<Story>
            {
                new Story
                {
                    Name = "Lost Mine Of Phandelver",
                    Description = "Lost Mine of Phandelver is an adventur is set a short distance from the city of Neverwinter in the Sword Coast region of the Forgotten Realms setting.",
                    FirstParagraphId = 1,
                }
            });
            context.SaveChanges();
        }

        private static void InitializeParagraphs(OstreCWebContext context)
        {
            if (context.Paragraphs.Any())
            {
                return;   // DB has been seeded
            }

            context.Paragraphs.AddRange(
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "You die, load the game or start over!",
                StoryId = 1
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "In the city of Neverwinter, a dwarf named Gundren Rockseeker asked you to bring a wagon load of provisions to the rough-and-tumble settlement of Phandalin, a couple of days' travel southeast of the city. Gundren was clearly excited and more than a little secretive about his reasons for the trip, saying only that he and his brothers had found \"something big\", and that he'd pay you ten gold pieces each for escorting his supplies safely to Barthen's Provisions, a trading post in Phandalin. He then set out ahead of you on horse, along with a warrior escort named Sildar Haliwinter, claiming he needed to arrive early to \"take care of business.\" You've spent the last few days following the High Road south from Neverwinter, and you've just recently veered east along the Triboar Trail. You've encountered no trouble so far, but this territory can be dangerous. Bandits and outlaws have been known to lurk along the trail.",
                StoryId = 1,
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "The wagon is packed full of an assortment of mining supplies and food. This includes a dozen sacks of flour, several casks ofsalted pork, two kegs ofstrong ale, shovels, picks, and crowbars (about a dozen each), and five lanterns with a small barrel of oil (about fiftyflasks in volume). The total value of the cargo is 100 gp.",
                StoryId = 1,
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "You've been on the Triboar Trail for about half a day. As you come around a bend, you spot two dead horses sprawled about fifty feet ahead of you, blocking the path. Each has several black-feathered arrows sticking out of it. The woods press close to the trail here, with a steep embankment and dense thickets on either side.",
                StoryId = 1
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.Test,
                StageDescription = "Perception test to see goblins",
                StoryId = 1,
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "The horses as belonging to Gundren Rockseeker and Sildar Hallwinter. They've been dead about a day, and it's clear that arrows killed the horses.",
                StoryId = 1,
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "Two goblins are hiding in the woods, one on each side of the road.",
                StoryId = 1
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "The saddlebags have been looted. Nearby lies an empty 1 leather map case.",
                StoryId = 1
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.Fight,
                StageDescription = "Fight with 2 goblin",
                StoryId = 1,
            },
            new Paragraph
            {
                ParagraphType = ParagraphType.DescOfStage,
                StageDescription = "You are looking at two dead goblins.",
                StoryId = 1
            });
            context.SaveChanges();
        }

        private static void InitializeChoices(OstreCWebContext context)
        {
            if (context.Choices.Any())
            {
                return;   // DB has been seeded
            }

            context.Choices.AddRange(
            new Choice
            {
                ChoiceText = "What's on the cart?",
                NextParagraphId = 2,
                ParagraphId = 1
            },
            new Choice
            {
                ChoiceText = "Next",
                NextParagraphId = 3,
                ParagraphId = 1
            },
            new Choice
            {
                ChoiceText = "Next",
                NextParagraphId = 3,
                ParagraphId = 2
            },
            new Choice
            {
                ChoiceText = "Look around",
                NextParagraphId = 4,
                ParagraphId = 3
            },
            new Choice
            {
                ChoiceText = "Come closer",
                NextParagraphId = 5,
                ParagraphId = 3
            },
            new Choice
            {
                ChoiceText = "Failure",
                NextParagraphId = 5,
                ParagraphId = 4
            },
            new Choice
            {
                ChoiceText = "Success",
                NextParagraphId = 6,
                ParagraphId = 4
            },
            new Choice
            {
                ChoiceText = "Get closer to the dead horses",
                NextParagraphId = 7,
                ParagraphId = 5
            },
            new Choice
            {
                ChoiceText = "Get closer to the dead horses",
                NextParagraphId = 7,
                ParagraphId = 6
            },
            new Choice
            {
                ChoiceText = "Attack goblins",
                NextParagraphId = 8,
                ParagraphId = 6
            },
            new Choice
            {
                ChoiceText = "Next",
                NextParagraphId = 8,
                ParagraphId = 7
            },
            new Choice
            {
                ChoiceText = "Defeat!",
                NextParagraphId = 0,
                ParagraphId = 8
            },
            new Choice
            {
                ChoiceText = "Victory!",
                NextParagraphId = 9,
                ParagraphId = 8
            },
            new Choice
            {
                ChoiceText = "Nothing else, kill your hero!",
                NextParagraphId = 0,
                ParagraphId = 9
            }
            );
            context.SaveChanges();
        }

        private static void InitializeFightProps(OstreCWebContext context)
        {
            if (context.FightProps.Any())
            {
                return;   // DB has been seeded
            }

            context.FightProps.AddRange(
                new FightProp
                {
                    ParagraphId = 8
                });
            context.SaveChanges();
        }

        private static void InitializeEnemyInParagraphs(OstreCWebContext context)
        {
            if (context.EnemyInParagraphs.Any())
            {
                return;   // DB has been seeded
            }

            context.EnemyInParagraphs.AddRange(
                new EnemyInParagraph
                {
                    AmountOfEnemy = 2,
                    EnemyId = 1,
                    EnemyName = "Goblin",
                    FightPropId = 1
                });
            context.SaveChanges();
        }

        private static void InitializeTestProps(OstreCWebContext context)
        {
            if (context.TestProps.Any())
            {
                return;   // DB has been seeded
            }

            context.TestProps.AddRange(
            new TestProp
            {
                Skill = Skills.Perception,
                TestDifficulty = TestDifficulty.Easy,
                ParagraphId = 4
            }
            );
            context.SaveChanges();
        }
    }
}
