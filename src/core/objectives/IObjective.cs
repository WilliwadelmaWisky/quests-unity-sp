using System;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.objectives
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
