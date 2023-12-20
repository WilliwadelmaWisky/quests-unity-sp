using System;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class StagedQuest : Quest
    {
        private readonly List<Stage> _stageList;
        private int _stageIndex;

        public int StageCount => _stageList.Count;
        public Stage Current => _stageList[_stageIndex];


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public StagedQuest(string id, string name, QuestType type) : base(id, name, type)
        {
            _stageList = new List<Stage>();
            _stageIndex = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Start(Action onCompleted)
        {
            base.Start(onCompleted);

            _stageIndex = 0;
            StartStage();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objective"></param>
        /// <param name="stage"></param>
        public void Add(Stage stage)
        {
            _stageList.Add(stage);
        }


        /// <summary>
        /// 
        /// </summary>
        private void StartStage()
        {
            if (_stageIndex >= StageCount)
            {
                Complete();
                return;
            }

            Current.ForEach((objective, index) =>
            {
                objective.Start(OnObjectiveCompleted);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnObjectiveCompleted()
        {
            if (!Current.IsCompleted())
                return;

            _stageIndex++;
            StartStage();
            TriggerUpdateCallback();
        }
    }
}
