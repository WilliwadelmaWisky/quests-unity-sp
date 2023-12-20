using System;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Stage
    {
        private readonly List<IObjective> _objectiveList;


        /// <summary>
        /// 
        /// </summary>
        public Stage()
        {
            _objectiveList = new List<IObjective>();
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
        /// <returns></returns>
        public bool IsCompleted()
        {
            for (int i = 0; i < _objectiveList.Count; i++)
            {
                if (_objectiveList[i].CompletionState == CompletionState.Active)
                    return false;
            }

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onLoop"></param>
        public void ForEach(Action<IObjective, int> onLoop)
        {
            for (int i = 0; i < _objectiveList.Count; i++)
                onLoop(_objectiveList[i], i);
        }
    }
}
