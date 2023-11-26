using System;

namespace WWWisky.quests.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestType : IComparable<IQuestType>
    {
        string Name { get; }
    }
}
