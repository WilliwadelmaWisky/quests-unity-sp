namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class EventSystem
    {
        public static EventSystem Current { get; } = new EventSystem();

        public delegate void EventReceivedDelegate(IEvent e);
        private event EventReceivedDelegate OnEventReceived;


        /// <summary>
        /// 
        /// </summary>
        public EventSystem()
        {
            OnEventReceived = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Broadcast(IEvent e)
        {
            OnEventReceived?.Invoke(e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onReceived"></param>
        public void AddListener(EventReceivedDelegate onReceived)
        {
            if (onReceived == null)
                return;

            OnEventReceived += onReceived;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onReceived"></param>
        public void RemoveListener(EventReceivedDelegate onReceived)
        {
            if (onReceived == null)
                return;

            OnEventReceived -= onReceived;
        }
    }
}
