using System;
using System.Collections.Generic;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestBoard
    {
        public event Action<IQuest> OnQuestAdded;
        public event Action<IQuest> OnQuestRemoved;

        public string Name { get; }
        private readonly List<IQuest> m_QuestList;


        public QuestBoard(string boardName)
        {
            Name = boardName;
            m_QuestList = new List<IQuest>();
        }


        public IEnumerable<IQuest> GetQuests() => m_QuestList;
        public int GetQuestCount() => m_QuestList.Count;


        public void AddQuest(IQuest quest)
        {
            if (quest == null)
                return;

            m_QuestList.Add(quest);
            OnQuestAdded?.Invoke(quest);
        }
        public void RemoveQuest(IQuest quest)
        {
            if (quest == null)
                return;

            m_QuestList.Remove(quest);
            OnQuestRemoved?.Invoke(quest);
        }
    }
}
