using System;
using System.Collections.Generic;
using WWWisky.quests.core.contracts;

namespace WWWisky.quests.core
{
    public class QuestBoard
    {
        public event Action<IQuest> OnQuestAdded;
        public event Action<IQuest> OnQuestRemoved;

        public string Name { get; }
        private readonly HashSet<Quest> m_QuestList;


        public QuestBoard(string boardName)
        {
            Name = boardName;
            m_QuestList = new HashSet<IQuest>();
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
