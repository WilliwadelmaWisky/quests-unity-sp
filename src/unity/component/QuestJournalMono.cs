using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestJournalMono : MonoBehaviour
    {
        private QuestJournal _questJournal;
        private QuestTracker _questTracker;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _questJournal = new QuestJournal();
            _questTracker = new QuestTracker();

            _questJournal.OnQuestEnded += OnQuestEnded;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        public void Add(IQuest quest)
        {
            if (!_questJournal.Add(quest))
                return;

            Debug.Log("Quest added: " + quest.Name);

            if (_questJournal.QuestCount > 1 || _questTracker.IsTracking)
                return;

            _questTracker.Track(quest);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        public void Abandon(IQuest quest)
        {
            if (!_questJournal.Contains(quest))
                return;

            _questJournal.AbandonQuest(quest);
            if (!_questTracker.IsTracking || !_questTracker.TrackedQuest.Equals(quest))
                return;

            _questJournal.ForEach((q, index) =>
            {
                _questTracker.Track(q);
                return;
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        private void OnQuestEnded(IQuest quest)
        {
            if (!_questTracker.IsTracking || !_questTracker.TrackedQuest.Equals(quest))
                return;

            _questJournal.ForEach((q, index) =>
            {
                _questTracker.Track(q);
                return;
            });
        }


        /// <summary>
        /// 
        /// </summary>
        public void Access()
        {
            Event_AccessQuestJournal e = new Event_AccessQuestJournal(this, _questJournal);
            EventSystem.Current.Broadcast(e);
        }
    }
}
