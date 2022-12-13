using OstreCWEB.Data.Repository.StoryModels;

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
                    Paragraphs = null,
                    FirstParagraphId = 3,
                    UserId = 1,
                },
                new Story
                {
                    Id = 2,
                    Name = "Two",
                    Description = "Pab",
                    Paragraphs = null,
                    FirstParagraphId = 2,
                    UserId = 1,
                },
                new Story
                {
                    Id = 3,
                    Name = "Three",
                    Description = "Restaurant",
                    Paragraphs = null,
                    FirstParagraphId = 1,
                    UserId = 1,
                }
            };

        public List<Story> GetAll()
        {
            return _stories;
        }
    }
}
