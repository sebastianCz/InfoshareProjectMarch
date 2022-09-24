using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OstreC
{
    internal class Results
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Desc { get; set; }
        public string Asi_desc { get; set; }
        public List<Asi> Asi { get; set; }
        public string Age { get; set; }
        public string Alignment { get; set; }
        public string Size { get; set; }
        public Speed Speed { get; set; }
        public string Speed_desc { get; set; }
        public string Languages { get; set; }
        public string Vision { get; set; }
        public string Traits { get; set; }
        public List<Subraces> Subraces { get; set; }
        public string Document__Slug { get; set; }
        public string Document__Title { get; set; }
        public string Document__license_url { get; set; }
    }
}
