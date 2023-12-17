using UnityEngine;
using WWWisky.quests.core.components;
using WWWisky.quests.core.quests;

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
    }
}
