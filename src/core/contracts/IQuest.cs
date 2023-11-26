using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.contracts
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

        void Start();
    }
}
