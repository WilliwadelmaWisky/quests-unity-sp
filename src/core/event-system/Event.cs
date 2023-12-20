namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Event : IEvent
    {
        public object Source { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public Event(object source)
        {
            Source = source;
        }
    }
}
