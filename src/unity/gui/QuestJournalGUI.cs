using UnityEngine;
using UnityEngine.Pool;
using WWWisky.quests.core.components;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestJournalGUI : MonoBehaviour
    {
        [SerializeField] private QuestGUI QuestPrefab;
        [SerializeField] private QuestListGUI QuestList;
        [Header("Optional")]
        [SerializeField] private QuestCategoryGUI QuestCategory;

        private QuestJournal _questJournal;
        private IObjectPool<QuestGUI> _questPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _questPool = new ObjectPool<QuestGUI>(() => 
            {
                QuestGUI questGUI = (QuestGUI)QuestPrefab.Clone();
                questGUI.transform.SetParent(QuestList.transform);
                return questGUI;
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questJournal"></param>
        public void Assign(QuestJournal questJournal)
        {
            _questJournal = questJournal;

            Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            QuestList.Clear().ForEach(questGUI => _questPool.Release(questGUI));
            _questJournal.ForEach((quest, index) =>
            {
                if (!ShowQuest(quest))
                    return;

                QuestList.Add(quest, _questPool.Get());
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        private bool ShowQuest(IQuest quest)
        {
            if (QuestCategory != null)
                return QuestCategory.Match(quest);

            return true;
        }
    }
}
