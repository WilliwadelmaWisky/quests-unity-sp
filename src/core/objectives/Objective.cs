using System;

namespace WWWisky.quests.core
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

        private Action _onCompleted;


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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onCompleted"></param>
        public virtual void Start(Action onCompleted)
        {
            _onCompleted = onCompleted;
            CompletionState = CompletionState.Active;
        }


        /// <summary>
        /// 
        /// </summary>
        protected void TriggerUpdateCallback() => OnUpdated?.Invoke();
		
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="completionState"></param>
		public void Complete(CompletionState completionState = CompletionState.Completed)
		{
            CompletionState = completionState;
            _onCompleted();
            OnUpdated?.Invoke();
		}
	}
}