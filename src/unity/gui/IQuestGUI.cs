using System;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestGUI : ICloneable
    {
        void Assign(IQuest quest);
        void Clear();
    }
}
