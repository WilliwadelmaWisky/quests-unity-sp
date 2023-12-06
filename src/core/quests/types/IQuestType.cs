using System;

namespace WWWisky.quests.core.quests.types
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestType : IComparable<IQuestType>
    {
        string Name { get; }
        bool IsRecorded { get; }
    }
}
