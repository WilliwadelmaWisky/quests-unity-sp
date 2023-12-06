using System;
using WWWisky.quests.core.quests.types;

namespace WWWisky.quests.core.quests
{
    /// <summary>
    /// 
    /// </summary>
    public class Quest : IQuest
	{
        public event Action OnUpdated;
		
        public string ID { get; }
		public string Name { get; }
        public IQuestType Type { get; }
        public CompletionState CompletionState { get; private set; }

        private Action _onCompleted;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public Quest(string id, string name, IQuestType type)
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
		public void Complete()
		{
            CompletionState = CompletionState.Completed;
            _onCompleted();
            OnUpdated?.Invoke();
		}

        /// <summary>
        /// 
        /// </summary>
		public void Fail()
		{
            CompletionState = CompletionState.Failed;
            OnUpdated?.Invoke();
		}
	}
}