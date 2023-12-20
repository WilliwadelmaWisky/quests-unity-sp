using System;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Quest : IQuest
	{
        public event Action OnUpdated;
		
        public string ID { get; }
		public string Name { get; }
        public QuestType Type { get; }
        public CompletionState CompletionState { get; private set; }

        private Action _onCompleted;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public Quest(string id, string name, QuestType type)
		{
            ID = id;
			Name = name;
            Type = type;
            CompletionState = CompletionState.NONE;
        }


        /// <summary>
        /// 
        /// </summary>
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