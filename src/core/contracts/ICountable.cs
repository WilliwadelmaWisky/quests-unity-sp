namespace WWWisky.quests.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICountable
    {
        int Current { get; }
        int Total { get; }

        void Increase(int amount);
        void Decrease(int amount);
    }
}
