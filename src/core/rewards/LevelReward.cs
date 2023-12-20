namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class LevelReward : Reward
    {
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public LevelReward(string name, int amount) : base(name)
        {
            Amount = amount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Give(object target)
        {
            if (target is ILevelable levelable)
                levelable.AddExperience(Amount);
        }
    }
}
