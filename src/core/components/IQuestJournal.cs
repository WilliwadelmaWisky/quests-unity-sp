using System.Collections.Generic;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestJournal : IEnumerable<IQuest>
    {
        int QuestCount { get; }
    }
}
