namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Event_AccessQuestJournal : Event
    {
        public IQuestJournal QuestJournal { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="questJournal"></param>
        public Event_AccessQuestJournal(object source, IQuestJournal questJournal) : base(source)
        {
            QuestJournal = questJournal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questJournal"></param>
        public Event_AccessQuestJournal(IQuestJournal questJournal) : this(questJournal, questJournal) { }
    }
}
