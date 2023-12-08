using UnityEngine;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestGUI : MonoBehaviour
    {
        public IQuest Quest { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        public virtual void Assign(IQuest quest)
        {
            Quest = quest;
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            Quest = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return Instantiate(this);
        }
    }
}
