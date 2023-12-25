using System;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestBoardGUI : MonoBehaviour
    {
        [SerializeField] private QuestGUI QuestPrefab;
        [SerializeField] private QuestListGUI QuestList;
        [Header("Optional")]
        [SerializeField] private TextMeshProUGUI NameText;
        [SerializeField] private QuestCategoryGUI QuestCategory;
        [SerializeField] private QuestInfoGUI QuestInfo;

        private IQuestBoard _questBoard;
        private IObjectPool<QuestGUI> _questPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _questPool = new ObjectPool<QuestGUI>(() => (QuestGUI)QuestPrefab.Clone());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questBoard"></param>
        public void Assign(IQuestBoard questBoard)
        {
            _questBoard = questBoard;
            NameText?.SetText(questBoard.Name);
            QuestInfo?.Hide();

            Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Refresh() => Refresh(quest => true);

        /// <summary>
        /// 
        /// </summary>
        public void Refresh(Predicate<IQuest> match)
        {
            QuestList.Clear().ForEach(questGUI => _questPool.Release(questGUI));
            _questBoard.ForEach((quest, index) =>
            {
                if (match(quest))
                    CreateQuest(quest, index);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        /// <param name="index"></param>
        private void CreateQuest(IQuest quest, int index)
        {
            QuestGUI questGUI = _questPool.Get();
            QuestList.Add(quest, questGUI);
            questGUI.OnClicked += () => OnQuestClicked(questGUI);
            questGUI.transform.SetSiblingIndex(index);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questGUI"></param>
        private void OnQuestClicked(QuestGUI questGUI)
        {
            if (questGUI == null || questGUI.Quest == null)
                return;

            QuestInfo?.Show(questGUI.Quest);
        }
    }
}
