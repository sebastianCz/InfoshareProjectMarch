using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository
{
    internal class Enemy : Character
    {
        //It's essentially the name of the enemy. I'm assuming enemies will have a different set of methods that's why this class exists. 
        public string Type { get; set; }
    }
}
