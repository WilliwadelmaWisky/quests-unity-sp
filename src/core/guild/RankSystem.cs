namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class RankSystem : LevelSystem
    {
        private readonly IGuildRank[] _ranks;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ranks"></param>
        public RankSystem(IGuildRank[] ranks) : base(ranks.Length - 1, rank => ranks[rank].RequiredExperience)
        {
            _ranks = ranks;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        protected override bool CanLevelUp(int level)
        {
            IGuildRank rank = _ranks[level];
            return rank.RequirementsMet();
        }
    }
}
