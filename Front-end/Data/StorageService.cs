using System.Collections.Generic;

namespace SentiTweetFE.Data
{
    public class StorageService
    {
        private Dictionary<string, string> dict;
        public StorageService()
        {
            dict = new Dictionary<string, string>();
        }
        public bool Has(string key)
        {
            return dict.ContainsKey(key);
        }
        public string Get(string key)
        {
            return dict[key];
        }

        public void Set(string key, string value)
        {
            dict[key] = value;
        }

        public void Del(string key)
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
        }
    }
}