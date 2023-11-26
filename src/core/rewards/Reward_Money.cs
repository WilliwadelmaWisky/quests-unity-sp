namespace QuestSystem
{
    public class Reward_Money : Reward
    {
        public int Amount { get; }


        public Reward_Money(string name, int amount) : base(name)
        {
            Amount = amount;
        }
        public Reward_Money(SaveObject saveObject) : base(saveObject)
        {
            Amount = saveObject.IntValues[0];
        }


        protected override void OnSaved(ref SaveObject saveObject)
        {
            saveObject.IntValues = new int[] { Amount };
        }
    }
}