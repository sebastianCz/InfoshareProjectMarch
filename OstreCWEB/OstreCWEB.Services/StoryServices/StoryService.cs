using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.Services.StoryServices.Models;

namespace OstreCWEB.Services.StoryServices
{
    internal class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IEnemyRepository _enemyRepository;

        public StoryService(IStoryRepository storyRepository, IEnemyRepository enemyRepository)
        {
            _storyRepository = storyRepository;
            _enemyRepository = enemyRepository;
        }

        public async Task<IReadOnlyCollection<Story>> GetAllStories()
        {
            return await _storyRepository.GetAllStories();
        }

        public async Task<IReadOnlyCollection<Story>> GetStoriesByUserId(string userId)
        {
            return await _storyRepository.GetStoriesByUserId(userId);
        }

        public async Task<Story> GetStoryById(int idStory)
        {
            return await _storyRepository.GetStoryById(idStory);
        }

        public async Task<Story> GetStoryWithParagraphsById(int idStory)
        {
            return await _storyRepository.GetStoryWithParagraphsById(idStory);
        }

        //Story

        public async Task AddStory(Story story, string userId)
        {
            story.UserId = userId;
            await _storyRepository.AddStory(story);
        }

        public async Task UpdateStory(int idStory, string Name, string Description, string userId)
        {
            var story = await _storyRepository.GetStoryById(idStory);

            if (story.UserId == userId)
            {
                story.Name = Name;
                story.Description = Description;

                await _storyRepository.UpdateStory(story);
            }
            else
            {
                throw new Exception("This is not your Story");
            }
        }

        public async Task DeleteStory(int idStory, string userId)
        {
            var story = await _storyRepository.GetStoryById(idStory);

            if (story.UserId == userId)
            {
                await _storyRepository.DeleteStory(story);
            }
            else
            {
                throw new Exception("This is not your Story");
            }
        }

        //Paragraph
        public async Task<Paragraph> GetParagraphById(int idParagraphId)
        {
            return await _storyRepository.GetParagraphById(idParagraphId);
        }


        public async Task AddParagraph(Paragraph paragraph, string userId)
        {
            var userStories = await _storyRepository.GetStoriesByUserId(userId);

            if (userStories.Any(s => s.Id == paragraph.StoryId))
            {
                if (paragraph.ParagraphType == ParagraphType.DescOfStage)
                {
                    await _storyRepository.AddParagraph(paragraph);
                }
                else if (paragraph.ParagraphType == ParagraphType.Test || paragraph.ParagraphType == ParagraphType.Fight)
                {
                    paragraph.Choices = new List<Choice>
                    {
                        new Choice
                        {
                            ChoiceText = "Failure - " + paragraph.StageDescription,
                            NextParagraphId = -1
                        },
                        new Choice
                        {
                            ChoiceText = "Success - " + paragraph.StageDescription,
                            NextParagraphId = -1
                        },
                    };
                    await _storyRepository.AddParagraph(paragraph);
                }
                else
                {
                    throw new NotImplementedException();
                }

                var stories = await _storyRepository.GetAllStories();
                var story = stories.FirstOrDefault(x => x.Id == paragraph.StoryId);
                if (story.GetAmountOfParagraphs() == 1)
                {
                    story.FirstParagraphId = story.Paragraphs[0].Id;
                    await _storyRepository.UpdateStory(story);
                }
            }
            else
            {
                throw new Exception("This is not your Story");
            }
        }
        public async Task DeleteParagraph(int idParagraph, string userId)
        {

            var paragraph = await _storyRepository.GetParagraphById(idParagraph);
            var story = await _storyRepository.GetStoryById(paragraph.StoryId);

            if (story.UserId == userId)
            {
                await _storyRepository.DeleteParagraph(story.Paragraphs.FirstOrDefault(p => p.Id == idParagraph));
            }
            else
            {
                throw new Exception("This is not your Story");
            }
        }

            public async Task<ParagraphDetails> GetParagraphDetailsById(int idParagraph, int idStory)
        {
            var story = await _storyRepository.GetStoryById(idStory);

            var paragraphDetails = new ParagraphDetails
            {
                StoryId = story.Id,
                NameOfStory = story.Name,
                DescriptionOfStory = story.Description,
                AmountOfParagraphs = story.GetAmountOfParagraphs(),
                CurrentParagraph = story.Paragraphs.FirstOrDefault(p => p.Id == idParagraph),
                NextParagraphs = new List<ParagraphWithCoice>(),
                PreviousParagraphs = new List<ParagraphWithCoice>()
            };

            if (paragraphDetails.CurrentParagraph.Choices.Count() != 0)
            {
                foreach (var item in paragraphDetails.CurrentParagraph.Choices)
                {
                    ParagraphWithCoice nextParagraphView;
                    if (item.NextParagraphId != -1)
                    {
                        var nextParagraph = story.Paragraphs.FirstOrDefault(p => p.Id == item.NextParagraphId);
                        nextParagraphView = new ParagraphWithCoice
                        {
                            Id = nextParagraph.Id,
                            ParagraphType = nextParagraph.ParagraphType,
                            StageDescription = nextParagraph.StageDescription,
                            AmountOfChoices = nextParagraph.GetAmountOfChoices(),
                            ChoiceId = item.Id,
                            DescriptionOfChoice = item.ChoiceText
                        };
                    }
                    else
                    {
                        nextParagraphView = new ParagraphWithCoice
                        { 
                            Id = -1,
                            ParagraphType = default,
                            StageDescription = "The paragraph doesn't exist",
                            AmountOfChoices = 0,
                            ChoiceId = item.Id,
                            DescriptionOfChoice = item.ChoiceText
                        };
                    }
                    paragraphDetails.NextParagraphs.Add(nextParagraphView);
                }
            }

            var previousParagraphs = story.Paragraphs.Where(s => s.Choices.Any(c => c.NextParagraphId == idParagraph)).ToList();

            if (previousParagraphs.Count > 0)
            {
                foreach (var item in previousParagraphs)
                {
                    var choice = item.Choices.FirstOrDefault(item => item.NextParagraphId == idParagraph);
                    ParagraphWithCoice previousParagraph = new ParagraphWithCoice
                    {
                        Id = item.Id,
                        ParagraphType = item.ParagraphType,
                        StageDescription = item.StageDescription,
                        AmountOfChoices = item.GetAmountOfChoices(),
                        ChoiceId = choice.Id,
                        DescriptionOfChoice = choice.ChoiceText
                    };

                    paragraphDetails.PreviousParagraphs.Add(previousParagraph);
                }
            }

            paragraphDetails.Delete = !paragraphDetails.PreviousParagraphs.Any
                (x => x.ParagraphType == ParagraphType.Fight || x.ParagraphType == ParagraphType.Test);

            if (paragraphDetails.CurrentParagraph.ParagraphType == ParagraphType.Fight || paragraphDetails.CurrentParagraph.ParagraphType == ParagraphType.Test)
            {
                paragraphDetails.CreatChoice = false;
            }
            else
            {
                paragraphDetails.CreatChoice = true;
            }

            return paragraphDetails;
        }

        public async Task<IReadOnlyCollection<Enemy>> GetAllEnemies()
        {
            return await _enemyRepository.GetAllTemplatesAsync();
        }

        public async Task<ChoiceDetails> GetChoiceDetailsById(int idChoice)
        {
            var choice = await _storyRepository.GetChoiceDetailsById(idChoice);

            var choiceDetails = new ChoiceDetails
            {
                StoryId = choice.Paragraph.Story.Id,
                DescriptionOfStory = choice.Paragraph.Story.Description,
                NameOfStory = choice.Paragraph.Story.Name,
                AmountOfParagraphs = choice.Paragraph.Story.GetAmountOfParagraphs(),
                PreviousParagraph = choice.Paragraph,
                CurrentChoice = choice,
                NextParagraph = choice.Paragraph.Story.Paragraphs.FirstOrDefault(p => p.Id == choice.NextParagraphId)
            };

            if(choiceDetails.PreviousParagraph.ParagraphType == ParagraphType.Fight || choiceDetails.PreviousParagraph.ParagraphType == ParagraphType.Test)
            {
                choiceDetails.Delete = false;
            }
            else
            {
                choiceDetails.Delete = true;
            }

            return choiceDetails;
        }
    }
}
