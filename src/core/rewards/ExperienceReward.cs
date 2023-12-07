using WWWisky.quests.core.guild;

namespace WWWisky.quests.core.rewards
{
    /// <summary>
    /// 
    /// </summary>
    public class ExperienceReward : Reward
    {
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public ExperienceReward(string name, int amount) : base(name)
        {
            Amount = amount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Give(object target)
        {
            if (target is IHasLevelSystem hasLevelSystem)
                hasLevelSystem.GetLevelSystem().AddExperience(Amount);
        }
    }
}
