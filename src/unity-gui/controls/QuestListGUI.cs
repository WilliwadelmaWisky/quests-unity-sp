using System.Collections.Generic;
using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestListGUI : MonoBehaviour
    {
        private List<QuestGUI> _questList;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _questList = new List<QuestGUI>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        /// <param name="questGUI"></param>
        public void Add(IQuest quest, QuestGUI questGUI)
        {
            questGUI.Clear();
            questGUI.Assign(quest);
            questGUI.transform.SetParent(transform);
            _questList.Add(questGUI);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questGUI"></param>
        /// <returns></returns>
        public QuestGUI Remove(QuestGUI questGUI)
        {
            int index = _questList.FindIndex(q => q.Equals(questGUI));
            return Remove(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public QuestGUI Remove(int index)
        {
            if (index < 0 || index >= _questList.Count)
                return null;

            QuestGUI questGUI = _questList[index];
            _questList.RemoveAt(index);
            questGUI.Clear();
            return questGUI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<QuestGUI> Clear()
        {
            List<QuestGUI> questList = new List<QuestGUI>(_questList);
            _questList.Clear();

            foreach (QuestGUI questGUI in questList)
                questGUI.Clear();

            return questList;
        }
    }
}
