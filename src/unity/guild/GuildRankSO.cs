using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class GuildRankSO : ScriptableObject, IGuildRank
    {
        [SerializeField] private string RankName;
        [SerializeField, Min(0)] private int Experience;

        public string Name => RankName;
        public int RequiredExperience => Experience;

        public bool RequirementsMet()
        {
            throw new System.NotImplementedException();
        }
    }
}
