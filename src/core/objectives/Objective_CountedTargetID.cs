using System;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Objective_CountedTargetID : Objective_TargetID, ICountable
    {
        public int Current { get; private set; }
        public int Total { get; }

        private readonly string _defaultName;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="targetID"></param>
        /// <param name="targetAmount"></param>
        public Objective_CountedTargetID(string id, string name, string targetID, int targetAmount) : base(id, name, targetID)
        {
			_defaultName = name;
            Total = Math.Max(targetAmount, 1);
            Current = 0;
            UpdateName();
        }


        public override void Start(Action onCompleted)
        {
            base.Start(onCompleted);

            Current = 0;
            UpdateName();
        }


        /// <summary>
        /// 
        /// </summary>
        private void UpdateName() => Name = _defaultName + " (" + Current + "/" + Total + ")";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public void Increase(int amount)
        {
            if (CompletionState != CompletionState.Active || amount <= 0)
                return;

            Current += Math.Min(amount, Total - Current);
            UpdateName();

            if (Current >= Total)
            {
                Complete();
                return;
            }

            TriggerUpdateCallback();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Decrease(int amount)
        {
            if (CompletionState != CompletionState.Active || amount <= 0)
                return;

            Current -= Math.Min(amount, Current);
            UpdateName();
            TriggerUpdateCallback();
        }
    }
}
