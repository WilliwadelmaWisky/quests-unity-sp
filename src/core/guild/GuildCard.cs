using System;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class GuildCard
    {
        public RankSystem RankSystem { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        public GuildCard(Guild guild)
        {
            IGuildRank[] ranks = guild.GetRanks();
            Array.Sort(ranks, new RankComparer());
            RankSystem = new RankSystem(ranks);
        }


        /// <summary>
        /// 
        /// </summary>
        private class RankComparer : IComparer<IGuildRank>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(IGuildRank x, IGuildRank y) => x.RequiredExperience.CompareTo(y.RequiredExperience);
        }
    }
}