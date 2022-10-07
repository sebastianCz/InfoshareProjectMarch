using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OstreC.Services.JsonFile;
using Newtonsoft.Json;
using System.Text.Json;

namespace OstreC.Services
{
    public class userResults
    {
        //[JsonExtensionData]
        //public Dictionary<string, JsonElement> AdditionalProperties { get; set; }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UsersList
    {

        public int Count { get; set; }
        public List<userResults> results { get; set; }



    }




}