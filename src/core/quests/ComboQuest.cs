using System;
using System.Collections.Generic;
using WWWisky.quests.core.objectives;
using WWWisky.quests.core.quests.types;

namespace WWWisky.quests.core.quests
{
    /// <summary>
    /// 
    /// </summary>
    public class ComboQuest : Quest
    {
        private readonly List<IObjective> _activeObjectiveList;
        private readonly List<IObjective> _allObjectiveList;
        private readonly Dictionary<int, List<int>> _stageIndecessDictionary;
        private int _stage;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public ComboQuest(string id, string name, IQuestType type) : base(id, name, type)
        {
            _allObjectiveList = new List<IObjective>();
            _activeObjectiveList = new List<IObjective>();
            _stageIndecessDictionary = new Dictionary<int, List<int>>();
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Start(Action onCompleted)
        {
            base.Start(onCompleted);

            _activeObjectiveList.Clear();
            _stage = 0;

            NextObjective();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objective"></param>
        /// <param name="stage"></param>
        public void Add(IObjective objective, int stage)
        {
            _allObjectiveList.Add(objective);
            int objectiveIndex = _allObjectiveList.Count - 1;
            if (!_stageIndecessDictionary.ContainsKey(stage))
                _stageIndecessDictionary.Add(stage, new List<int>());
            _stageIndecessDictionary[stage].Add(objectiveIndex);
        }


        /// <summary>
        /// 
        /// </summary>
        private void NextObjective()
        {
            if (!_stageIndecessDictionary.ContainsKey(_stage))
            {
                Complete();
                return;
            }

            List<int> objectiveIndexList = _stageIndecessDictionary[_stage];
            foreach (int index in objectiveIndexList)
            {
                IObjective objective = _allObjectiveList[index];
                objective.Start(OnObjectiveCompleted);
                _activeObjectiveList.Add(objective);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnObjectiveCompleted()
        {
            for (int i = 0; i < _activeObjectiveList.Count; i++)
            {
                if (_activeObjectiveList[i].CompletionState == CompletionState.Active)
                    return;
            }

            _stage++;
            NextObjective();
            TriggerUpdateCallback();
        }
    }
}
