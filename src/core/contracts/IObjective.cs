using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObjective
    {
        string ID { get; }
        string Name { get; }
        CompletionState CompletionState { get; }

        void Start();
    }
}
