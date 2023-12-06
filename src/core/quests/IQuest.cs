using System;
using WWWisky.quests.core.quests.types;

namespace WWWisky.quests.core.quests
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuest
    {
        string ID { get; }
        string Name { get; }
        IQuestType Type { get; }
        CompletionState CompletionState { get; }

        void Start(Action onCompleted);
    }
}
