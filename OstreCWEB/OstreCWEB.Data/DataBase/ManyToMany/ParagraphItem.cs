using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.DataBase.ManyToMany
{
    public class ParagraphItem
    {
        public int AmountOfItems { get; set; }

        // Db relations properties
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ParagraphId { get; set; }
        public Paragraph Paragraph { get; set; }
    }
}
