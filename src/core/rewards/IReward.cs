namespace WWWisky.quests.core
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
