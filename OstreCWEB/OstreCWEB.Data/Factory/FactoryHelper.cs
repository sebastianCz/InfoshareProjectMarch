using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Factory
{
    public static class FactoryHelper
    {
        public static T GenerateNewObjectInstance<T>(T objectInstance)
        {
            var objectAsText = JsonConvert.SerializeObject(
                         objectInstance,
                     new JsonSerializerSettings()
                     {
                         TypeNameHandling = TypeNameHandling.Auto
                     });

            var newObjectInstance = JsonConvert.DeserializeObject<T>(
                objectAsText,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            return newObjectInstance; 
        }
    }
}
