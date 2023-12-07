using UnityEngine;
using UnityEngine.Pool;
using WWWisky.quests.core.components;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestJournalGUI : MonoBehaviour
    {
        [SerializeField] private QuestGUI QuestPrefab;
        [SerializeField] private QuestListGUI QuestList;

        private QuestJournal _questJournal;
        private IObjectPool<IQuestGUI> _questPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _questPool = new ObjectPool<IQuestGUI>(() => (IQuestGUI)QuestPrefab.Clone());
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
                QuestList.Add(quest, _questPool.Get());
            });
        }
    }
}
