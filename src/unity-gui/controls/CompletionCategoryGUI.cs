using System;
using System.Collections.Generic;
using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class CompletionCategoryGUI : QuestCategoryGUI
    {
        [SerializeField] private CategoryButtonGUI ButtonPrefab;

        public CompletionState Selected { get; private set; }

        private List<CategoryButtonGUI> _buttonList;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            Selected = CompletionState.Active;
            _buttonList = new List<CategoryButtonGUI>();
            Array categories = Enum.GetValues(typeof(CompletionState));

            for (int i = 0; i < categories.Length; i++)
            {
                CompletionState completionState = (CompletionState)categories.GetValue(i);
                if (completionState != CompletionState.NONE)
                    AddButton(completionState);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="completionState"></param>
        private void AddButton(CompletionState completionState)
        {
            CategoryButtonGUI buttonGUI = (CategoryButtonGUI)ButtonPrefab.Clone();
            buttonGUI.transform.SetParent(transform);
            buttonGUI.Assign(completionState, () => OnCategorySelected(buttonGUI.CompletionState));
            _buttonList.Add(buttonGUI);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        public override bool Match(IQuest quest) => quest.CompletionState == Selected;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="completionState"></param>
        private void OnCategorySelected(CompletionState completionState)
        {
            Selected = completionState;
        }
    }
}
