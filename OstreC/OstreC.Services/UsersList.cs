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
    public abstract class UsersList
    { 
        public string filepath { get; set; }
        public List<User> results { get; set; }
  
    }
     
}