using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Services.Models;

namespace OstreCWEB.Services.StoryServices
{
    internal class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
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
                new Exception("This is not your Story");
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
                new Exception("This is not your Story");
            }
        }

        //Paragraph
        public async Task AddParagraph(Paragraph paragraph, string userId)
        {
            var userStories = await _storyRepository.GetStoriesByUserId(userId);

            if (userStories.Any(s => s.Id == paragraph.StoryId))
            {
                await _storyRepository.AddParagraph(paragraph);
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
                new Exception("This is not your Story");
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
                CurrentParagraphView = story.Paragraphs.FirstOrDefault(p => p.Id == idParagraph),
                NextParagraphs = new List<ParagraphWithCoice>(),
                PreviousParagraphs = new List<ParagraphWithCoice>()
            };

            if (paragraphDetails.CurrentParagraphView.Choices.Count() != 0)
            {
                foreach (var item in paragraphDetails.CurrentParagraphView.Choices)
                {
                    var nextParagraph = story.Paragraphs.FirstOrDefault(p => p.Id == item.NextParagraphId);
                    ParagraphWithCoice nextParagraphView = new ParagraphWithCoice
                    {
                        Id = nextParagraph.Id,
                        ParagraphType = nextParagraph.ParagraphType,
                        StageDescription = nextParagraph.StageDescription,
                        AmountOfChoices = nextParagraph.GetAmountOfChoices(),
                        DescriptionOfChoice = item.ChoiceText
                    };

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
                        DescriptionOfChoice = choice.ChoiceText
                    };

                    paragraphDetails.PreviousParagraphs.Add(previousParagraph);
                }
            }

            paragraphDetails.Delete = !paragraphDetails.PreviousParagraphs.Any
                (x => x.ParagraphType == ParagraphType.Fight || x.ParagraphType == ParagraphType.Test);

            return paragraphDetails;
        }
    }
}
