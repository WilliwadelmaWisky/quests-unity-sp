using System;
using System.Collections;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestBoard : IQuestBoard
    {
        public event Action<IQuest> OnQuestAdded;
        public event Action<IQuest> OnQuestRemoved;

        public string Name { get; }

        private readonly List<IQuest> _questList;

        public int QuestCount => _questList.Count;


        public QuestBoard(string name)
        {
            Name = name;
            _questList = new List<IQuest>();
        }


        public IEnumerable<IQuest> GetQuests() => _questList;
        public int GetQuestCount() => _questList.Count;


        public void AddQuest(IQuest quest)
        {
            if (quest == null)
                return;

            _questList.Add(quest);
            OnQuestAdded?.Invoke(quest);
        }
        public void RemoveQuest(IQuest quest)
        {
            if (quest == null)
                return;

            _questList.Remove(quest);
            OnQuestRemoved?.Invoke(quest);
        }

        public IEnumerator<IQuest> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
