namespace WWWisky.quests.core.quests.types
{
    /// <summary>
    /// 
    /// </summary>
    public class MainQuest : IQuestType
    {
        public string Name { get; } = "Main Quest";
        public bool IsRecorded { get; } = true;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IQuestType other) => Name.CompareTo(other.Name);
    }
}
