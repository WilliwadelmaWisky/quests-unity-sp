using UnityEngine;
using UnityEngine.UI;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(QuestJournalGUI), typeof(WindowGUI))]
    public class QuestJournalControllerGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button CloseButton;

        protected QuestJournalGUI QuestJournalGUI { get; private set; }
        protected WindowGUI WindowGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            QuestJournalGUI = GetComponent<QuestJournalGUI>();
            WindowGUI = GetComponent<WindowGUI>();

            CloseButton?.onClick.AddListener(CloseQuestJournalGUI);
            EventSystem.Current.AddListener(OnEventReceived);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDestroy()
        {
            EventSystem.Current.RemoveListener(OnEventReceived);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEventReceived(IEvent e)
        {
            if (e is Event_AccessQuestJournal accessQuestJournalEvent)
                OpenQuestJournalGUI(accessQuestJournalEvent.QuestJournal);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questJournal"></param>
        public void OpenQuestJournalGUI(IQuestJournal questJournal)
        {
            QuestJournalGUI.Assign(questJournal);
            WindowGUI.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseQuestJournalGUI()
        {
            WindowGUI.Hide();
        }
    }
}
