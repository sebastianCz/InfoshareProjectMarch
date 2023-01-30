using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OstreCWEB.Services.Models
{
    public class ParagraphWithCoice
    {
        public int Id { get; set; }
        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }
        public int AmountOfChoices { get; set; }
        public string DescriptionOfChoice { get; set; }
    }
}
