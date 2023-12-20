namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestTracker
    {
        public IQuest TrackedQuest { get; private set; }

        public bool IsTracking => TrackedQuest != null;


        /// <summary>
        /// 
        /// </summary>
        public QuestTracker()
        {
            TrackedQuest = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        public void Track(IQuest quest)
        {
            TrackedQuest = quest;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            TrackedQuest = null;
        }
    }
}
