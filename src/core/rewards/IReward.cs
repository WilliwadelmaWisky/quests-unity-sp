namespace WWWisky.quests.core.rewards
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReward
    {
        string Name { get; }

        void Give(object target);
    }
}
