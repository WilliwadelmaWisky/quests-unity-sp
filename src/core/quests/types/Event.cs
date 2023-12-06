namespace WWWisky.quests.core.quests.types
{
    /// <summary>
    /// 
    /// </summary>
    public class Event : IQuestType
    {
        public string Name { get; } = "Event";
        public bool IsRecorded { get; } = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IQuestType other) => Name.CompareTo(other.Name);
    }
}
