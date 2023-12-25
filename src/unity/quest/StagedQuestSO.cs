using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class StagedQuestSO : QuestSO
    {
        [SerializeField] private StageSO[] Stages;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="questType"></param>
        /// <returns></returns>
        protected override IQuest OnCreate(string id, string name, QuestType questType)
        {
            StagedQuest quest = new StagedQuest(id, name, questType);
            foreach (StageSO stageSO in Stages)
                quest.Add(stageSO.Create());

            return quest;
        }
    }
}
