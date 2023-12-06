namespace WWWisky.quests.core.quests.types
{
    /// <summary>
    /// 
    /// </summary>
    public class SideQuest : IQuestType
    {
        public string Name { get; } = "Side Quest";
        public bool IsRecorded { get; } = true;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IQuestType other) => Name.CompareTo(other.Name);
    }
}
