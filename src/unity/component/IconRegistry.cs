using System.Collections.Generic;
using UnityEngine;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class IconRegistry
    {
        public static IconRegistry Current { get; } = new IconRegistry();
        private readonly Dictionary<string, Sprite> _iconDictionary;


        /// <summary>
        /// 
        /// </summary>
        private IconRegistry() => _iconDictionary = new Dictionary<string, Sprite>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Sprite Get(string key)
        {
            if (string.IsNullOrEmpty(key) || !_iconDictionary.ContainsKey(key))
                return null;

            return _iconDictionary[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="icon"></param>
        public void Register(string key, Sprite icon)
        {
            if (string.IsNullOrEmpty(key) || _iconDictionary.ContainsKey(key) || icon == null)
                return;

            _iconDictionary.Add(key, icon);
        }
    }
}
