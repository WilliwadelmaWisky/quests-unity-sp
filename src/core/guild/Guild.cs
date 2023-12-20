using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Guild
    {
        public string Name { get; }

        private readonly List<IGuildRank> _rankList;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public Guild(string name)
        {
            Name = name;
            _rankList = new List<IGuildRank>();
        }


        public IGuildRank[] GetRanks() => _rankList.ToArray();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank"></param>
        public void AddRank(IGuildRank rank)
        {
            if (rank == null)
                return;

            _rankList.Add(rank);
        }
    }
}
