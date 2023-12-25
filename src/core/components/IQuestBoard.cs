using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestBoard : IEnumerable<IQuest>
    {
        string Name { get; }
        int QuestCount { get; }
    }
}
