using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OstreC.Services.JsonFile;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace OstreC.Services
{
    //Can be used to deserialize items. Eventually.  
    public class ItemsList
    { 
       
        public List<Items> Results { get; set; }
  
    }
  
     
}