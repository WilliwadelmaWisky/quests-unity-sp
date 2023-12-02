using System;
using System.Collections.Generic;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestHistory
    {
        private readonly List<IQuest> _questList;
        private readonly HashSet<string> _questIDSet;


        /// <summary>
        /// 
        /// </summary>
        public QuestHistory()
        {
            _questList = new List<IQuest>();
            _questIDSet = new HashSet<string>();
        }


		public bool Contains(IQuest quest) => _questIDSet.Contains(quest.ID);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="onLoop"></param>
		public void ForEach(Action<IQuest> onLoop)
		{
			for (int i = _questList.Count - 1; i >= 0; i--)
				onLoop(_questList[i]);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="quest"></param>
		public void Add(IQuest quest)
		{
			if (quest == null || Contains(quest) || !quest.Type.IsRecorded)
				return;

			_questList.Add(quest);
			_questIDSet.Add(quest.ID);
		}
	}
}
