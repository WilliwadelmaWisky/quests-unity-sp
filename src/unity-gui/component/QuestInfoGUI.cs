using TMPro;
using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class QuestInfoGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI NameText;
        [SerializeField] private TextMeshProUGUI DescriptionText;
        [SerializeField] private TextMeshProUGUI TypeText;
        [SerializeField] private TextMeshProUGUI LocationText;

        private CanvasGroup _canvasGroup;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();

            Hide();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        public void Show(IQuest quest)
        {
            NameText.SetText(quest.Name);
            DescriptionText.SetText(DescriptionRegistry.Current.Get(quest.ID));
            DescriptionText.rectTransform.sizeDelta = new Vector2(DescriptionText.rectTransform.sizeDelta.x, DescriptionText.preferredHeight);

            TypeText.SetText(quest.Type.ToString().Replace('_', ' '));

            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0;
        }
    }
}
