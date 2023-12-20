namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Reward : IReward
    {
        public string Name { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public Reward(string name)
        {
            Name = name;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public abstract void Give(object target);
    }
}
