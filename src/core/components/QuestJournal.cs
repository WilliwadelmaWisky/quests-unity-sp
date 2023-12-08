using System;
using System.Collections.Generic;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestJournal
	{
		public event Action<IQuest> OnQuestAdded;
		public event Action<IQuest> OnQuestRemoved;
		public event Action<IQuest> OnQuestEnded;
		public event Action<IQuest> OnQuestAbandonned;

		private readonly List<IQuest> _questList;
		private readonly HashSet<string> _questIDSet;
		private readonly QuestHistory _history;

		public int QuestCount => _questList.Count;
		
		
		/// <summary>
		/// 
		/// </summary>
		public QuestJournal()
		{
			_questList = new List<IQuest>();
			_questIDSet = new HashSet<string>();
			_history = new QuestHistory();
		}
		
		
		public bool Contains(IQuest quest) => _questIDSet.Contains(quest.ID);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="onLoop"></param>
		public void ForEach(Action<IQuest, int> onLoop)
        {
			for (int i = 0; i < QuestCount; i++)
				onLoop(_questList[i], i);
        }
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="quest"></param>
		/// <returns></returns>
		public bool Add(IQuest quest)
		{
			if (quest == null || Contains(quest) || quest.CompletionState != CompletionState.NONE)
				return false;
			
			quest.Start(OnQuestCompleted);
			_questList.Add(quest);
			_questIDSet.Add(quest.ID);

			OnQuestAdded?.Invoke(quest);
            return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="quest"></param>
		private void RemoveQuest(IQuest quest)
        {
			_questList.Remove(quest);
			_questIDSet.Remove(quest.ID);
			_history.Add(quest);

			OnQuestRemoved?.Invoke(quest);
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="quest"></param>
		public void EndQuest(IQuest quest)
		{
			if (!Contains(quest))
				return;

			RemoveQuest(quest);
			OnQuestEnded?.Invoke(quest);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="quest"></param>
		public void AbandonQuest(IQuest quest)
		{
			if (!Contains(quest))
				return;

			RemoveQuest(quest);
			OnQuestAbandonned?.Invoke(quest);
		}


		/// <summary>
		/// 
		/// </summary>
		private void OnQuestCompleted()
        {
			for (int i = QuestCount - 1; i >= 0; i--)
            {
				IQuest quest = _questList[i];
				if (quest.CompletionState == CompletionState.Active)
					continue;

				EndQuest(quest);
            }
		}
	}
}