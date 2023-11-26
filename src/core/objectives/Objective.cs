using System;
using WWWisky.quests.core.contracts;
using WWWisky.quests.core.quests;

namespace WWWisky.quests.core.objectives
{
    /// <summary>
    /// 
    /// </summary>
    public class Objective : IObjective
	{
        public event Action OnUpdated;

        public string ID { get; }
		public string Name { get; protected set; }
		public CompletionState CompletionState { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Objective(string id, string name) 
        {
            ID = id;
            Name = name;
            CompletionState = CompletionState.NONE;
        }


        public void Start()
        {
            CompletionState = CompletionState.Active;
        }


        protected void UpdateCallback()
        {
            OnUpdated?.Invoke();
        }
		
		
		public void Complete()
		{
            CompletionState = CompletionState.Completed;
            OnUpdated?.Invoke();
		}
		public void Fail()
		{
            CompletionState = CompletionState.Failed;
            OnUpdated?.Invoke();
		}
	}
}