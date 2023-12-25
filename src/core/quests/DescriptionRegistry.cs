using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class DescriptionRegistry
    {
        public static DescriptionRegistry Current { get; } = new DescriptionRegistry();
        private readonly Dictionary<string, string> _descriptionDictionary;


        /// <summary>
        /// 
        /// </summary>
        private DescriptionRegistry() => _descriptionDictionary = new Dictionary<string, string>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            if (string.IsNullOrEmpty(key) || !_descriptionDictionary.ContainsKey(key))
                return string.Empty;

            return _descriptionDictionary[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="description"></param>
        public void Register(string key, string description)
        {
            if (string.IsNullOrEmpty(key) || _descriptionDictionary.ContainsKey(key) || string.IsNullOrEmpty(description))
                return;

            _descriptionDictionary.Add(key, description);
        }
    }
}
