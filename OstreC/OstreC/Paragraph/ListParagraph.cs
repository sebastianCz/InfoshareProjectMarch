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
}
