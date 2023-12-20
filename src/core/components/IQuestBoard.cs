using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestBoard : IEnumerable<IQuest>
    {
        int QuestCount { get; }
    }
}
