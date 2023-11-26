using UnityEngine;
using WWWisky.quests.core.guild;

namespace WWWisky.quests.unity.guild
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
    }
}
