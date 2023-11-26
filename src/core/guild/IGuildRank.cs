namespace WWWisky.quests.core.guild
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGuildRank
    {
        string Name { get; }
        int RequiredExperience { get; }

        bool RequirementsMet();
    }
}
