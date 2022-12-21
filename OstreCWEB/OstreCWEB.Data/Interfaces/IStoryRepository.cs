﻿using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.Interfaces
{
    public interface IStoryRepository
    {
        public IReadOnlyCollection<Story> GetAllStories();
        public Story GetStoryById(int idStory);
        public Paragraph GetParagraphById(int idParagraph);
    }
}
