using System;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuest
    {
        string ID { get; }
        string Name { get; }
        QuestType Type { get; }
        CompletionState CompletionState { get; }

        void Start(Action onCompleted);
    }
}
