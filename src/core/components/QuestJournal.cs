using System;
using System.Collections;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestJournal : IQuestJournal
	{
		public event Action<IQuest> OnQuestAdded;
		public event Action<IQuest> OnQuestRemoved;
		public event Action<IQuest> OnQuestEnded;
		public event Action<IQuest> OnQuestAbandonned;

		private readonly List<IQuest> _questList;
		private readonly HashSet<string> _questIDSet;
        private readonly List<IQuest> _activeQuestList;

		public int QuestCount => _questList.Count;
		
		
		/// <summary>
		/// 
		/// </summary>
		public QuestJournal()
		{
			_questList = new List<IQuest>();
			_questIDSet = new HashSet<string>();
            _activeQuestList = new List<IQuest>();
		}


        public IEnumerator<IQuest> GetEnumerator() => _questList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public bool Contains(IQuest quest) => _questIDSet.Contains(quest.ID);
		
		
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
            _activeQuestList.Add(quest);
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
			_activeQuestList.Remove(quest);

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
			for (int i = _activeQuestList.Count; i >= 0; i--)
            {
				IQuest quest = _activeQuestList[i];
				if (quest.CompletionState == CompletionState.Active)
					continue;

				EndQuest(quest);
            }
		}
    }
}