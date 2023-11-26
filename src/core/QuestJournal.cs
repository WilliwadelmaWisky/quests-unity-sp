using System;
using System.Collections.Generic;
using WWWisky.quests.core.contracts;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestJournal
	{
		public event Action<IQuest> OnQuestAdded;
		public event Action<IQuest> OnQuestEnded;
		public event Action<IQuest> OnQuestCompleted;
		public event Action<IQuest> OnQuestFailed;
        public event Action<IQuest> OnQuestAbandonned;
		
		private readonly List<IQuest> _activeQuestList;
		private readonly HashSet<string> _questIDSet;
		private readonly HashSet<IQuest> m_AllQuestList;
		
		
		public QuestJournal()
		{
			_activeQuestList = new List<IQuest>();
			m_AllQuestList = new HashSet<IQuest>();
			_questIDSet = new HashSet<string>();
		}
		
		
		public bool Contains(IQuest quest) => _questIDSet.Contains(quest.ID);


		public void ForEach(Action<IQuest> onLoop)
        {
			for (int i = _activeQuestList.Count - 1; i >= 0; i--)
				onLoop(_activeQuestList[i]);
        }
		
		
		public bool AddQuest(IQuest quest)
		{
			if (quest == null || Contains(quest) || quest.CompletionState != CompletionState.NONE)
				return false;
			
			m_AllQuestList.Add(quest);
			quest.Start();

			_activeQuestList.Add(quest);

			OnQuestAdded?.Invoke(quest);
            return true;
		}
		
		
		public void AbandonQuest(IQuest quest)
		{
			if (quest == null)
				return;

            EndQuest(quest);
			m_AllQuestList.Remove(quest);
            OnQuestAbandonned?.Invoke(quest);
		}
		public void EndQuest(IQuest quest)
		{
			if (quest == null)
				return;
			
			_activeQuestList.Remove(quest);
            OnQuestEnded?.Invoke(quest);
		}
	}
}