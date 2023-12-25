using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObjectiveSO : ScriptableObject
    {
        [SerializeField] protected string ID;
        [SerializeField] protected string Name;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObjective Create() => OnCreate();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract IObjective OnCreate();
    }
}
