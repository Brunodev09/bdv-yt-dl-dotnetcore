using System;
using Newtonsoft.Json;

namespace BdvYoutubeDotnet
{
    public class Deserializer
    {
        public static T Deserialize<T>(string RawData) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(RawData);
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return null;
            }
        }
    }
}