using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC
{
    internal class Subraces
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Desc { get; set; }
        public List<Asi> Asi { get; set; }
        public string Traits { get; set; }
        public string Asi_desc { get; set; }
        public string Document__Slug { get; set; }
        public string Document__Title { get; set; }
    }
}
