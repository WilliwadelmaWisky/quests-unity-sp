using UnityEngine;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class WindowGUI : MonoBehaviour
    {
        protected CanvasGroup CanvasGroup { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            SetVisibleImmediate(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isVisible"></param>
        public void SetVisible(bool isVisible)
        {
            if (isVisible)
            {
                Show();
                return;
            }

            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isVisible"></param>
        public void SetVisibleImmediate(bool isVisible)
        {
            CanvasGroup.alpha = isVisible ? 1 : 0;
            CanvasGroup.blocksRaycasts = isVisible;
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Show()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.blocksRaycasts = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Hide()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.blocksRaycasts = false;
        }
    }
}
