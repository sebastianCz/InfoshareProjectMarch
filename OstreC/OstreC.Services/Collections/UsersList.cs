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
    //Used for deserialization during Login validations and when modifying users/deleting/adding users. 
    public class UsersList
    { 
       
        public List<User> Results { get; set; }
  
    }
  
     
}