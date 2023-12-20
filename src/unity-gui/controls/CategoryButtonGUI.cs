using System;
using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoryButtonGUI : MonoBehaviour, ICloneable
    {
        public CompletionState CompletionState { get; private set; }

        private Action _onClicked;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="completionState"></param>
        public void Assign(CompletionState completionState, Action onClicked)
        {
            CompletionState = completionState;
            _onClicked = onClicked;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Click()
        {
            _onClicked();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone() => Instantiate(this);
    }
}
