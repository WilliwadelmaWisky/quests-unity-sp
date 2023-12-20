using System;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjQuest : Quest
    {
        private readonly List<IObjective> _objectiveList;
        private int _objectiveIndex;

        public int ObjectiveCount => _objectiveList.Count;
        public IObjective Current => _objectiveList[_objectiveIndex];


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public ObjQuest(string id, string name, QuestType type) : base(id, name, type)
        {
            _objectiveList = new List<IObjective>();
            _objectiveIndex = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Start(Action onCompleted)
        {
            base.Start(onCompleted);

            _objectiveIndex = 0;
            StartObjective();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objective"></param>
        public void Add(IObjective objective)
        {
            _objectiveList.Add(objective);
        }


        /// <summary>
        /// 
        /// </summary>
        private void StartObjective()
        {
            if (_objectiveIndex >= ObjectiveCount)
            {
                Complete();
                return;
            }

            Current.Start(OnObjectiveCompleted);
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnObjectiveCompleted()
        {
            _objectiveIndex++;
            StartObjective();
            TriggerUpdateCallback();
        }
    }
}
