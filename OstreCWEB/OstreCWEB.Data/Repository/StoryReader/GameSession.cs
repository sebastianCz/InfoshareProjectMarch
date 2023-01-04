using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.Repository.WebObjects
{
    //It will be replaced by story reader mclasses most likely.
    public class GameInstance
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public User User { get; set; }
        public int ParagraphId { get; set; }
        public Paragraph paragraph { get; set; }
        
    }
}
