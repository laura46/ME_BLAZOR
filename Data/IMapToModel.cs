using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CVWebsite.Data
{
    public interface IMapToModel<T>
    {
        public List<T> MapJsonToList(string jsonPath) 
        {
            try
            {
                T[] itemArray = JsonConvert.DeserializeObject<T[]>(File.ReadAllText(jsonPath));
                return itemArray.ToList<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
