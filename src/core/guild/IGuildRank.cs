namespace WWWisky.quests.core
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
