namespace WWWisky.quests.core
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
