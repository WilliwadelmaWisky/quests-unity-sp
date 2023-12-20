namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class RankReward : Reward
    {
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public RankReward(string name, int amount) : base(name)
        {
            Amount = amount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Give(object target)
        {
            if (target is IGuildMember guildMember)
                guildMember.GetGuildCard().RankSystem.AddExperience(Amount);
        }
    }
}
