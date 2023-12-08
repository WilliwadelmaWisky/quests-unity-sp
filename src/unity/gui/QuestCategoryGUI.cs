using UnityEngine;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class QuestCategoryGUI : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        public abstract bool Match(IQuest quest);
    }
}
