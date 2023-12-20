using System;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObjective
    {
        string ID { get; }
        string Name { get; }
        CompletionState CompletionState { get; }

        void Start(Action onCompleted);
    }
}
