using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Paragraph
{
    internal class ListParagraph
    {
        public int Count 
        { get 
            { return Paragraph.Count(); } 
        }
        public List<Paragraphs> Paragraph { get; set; }
    }

    internal class Paragraphs
    {
        public int IdParagraph { get; set; }
        public string TextParagraph { get; set; }
        public int HowManyOptions { get { return NextParagraph.Count(); } }
        public List<NextParagraph> NextParagraph { get; set; }
    }

    internal class NextParagraph
    {
        public string ChoiceText { get; set; }
        public int IdParagraph { get; set; }
    }
}
