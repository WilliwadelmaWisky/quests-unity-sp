using System.Collections.Generic;
using UnityEngine;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestListGUI : MonoBehaviour
    {
        private List<IQuestGUI> _questList;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _questList = new List<IQuestGUI>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        /// <param name="questGUI"></param>
        public void Add(IQuest quest, IQuestGUI questGUI)
        {
            questGUI.Clear();
            questGUI.Assign(quest);
            _questList.Add(questGUI);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questGUI"></param>
        /// <returns></returns>
        public IQuestGUI Remove(IQuestGUI questGUI)
        {
            int index = _questList.FindIndex(q => q.Equals(questGUI));
            return Remove(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IQuestGUI Remove(int index)
        {
            if (index < 0 || index >= _questList.Count)
                return null;

            IQuestGUI questGUI = _questList[index];
            _questList.RemoveAt(index);
            return questGUI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IQuestGUI> Clear()
        {
            List<IQuestGUI> questList = new List<IQuestGUI>(_questList);
            _questList.Clear();
            return questList;
        }
    }
}
