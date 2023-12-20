using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestGUI : MonoBehaviour, ICloneable, IPointerClickHandler
    {
        public event Action OnClicked;

        [SerializeField] private TextMeshProUGUI NameText;

        public IQuest Quest { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        public virtual void Assign(IQuest quest)
        {
            Quest = quest;
            NameText.SetText(Quest.Name);
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            if (Quest == null)
                return;

            Quest = null;
            OnClicked = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return Instantiate(this);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }
    }
}
