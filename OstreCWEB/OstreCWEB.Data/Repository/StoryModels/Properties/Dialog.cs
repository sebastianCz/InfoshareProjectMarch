﻿namespace OstreCWEB.Data.Repository.StoryModels.Properties
{
    public class Dialog
    {
        // General
        public int Id { get; set; }

        // Db relations properties
        public int ParagraphId { get; set; }
        public Paragraph Paragraph { get; set; }
    }
}
