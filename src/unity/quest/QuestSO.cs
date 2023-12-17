using UnityEngine;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class QuestSO : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IQuest Create();


        public abstract void RegisterIcon();
    }
}
