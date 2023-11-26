using System;
using System.Collections.Generic;

namespace QuestSystem
{
    public abstract class Reward
    {
        public string Name { get; }


        public static SaveObject Save(Reward reward)
        {
            SaveObject saveObject = reward.Save();
            return saveObject;
        }
        public static IEnumerable<SaveObject> SaveQuery(IEnumerable<Reward> rewardQuery)
        {
            List<SaveObject> saveObjectList = new List<SaveObject>();
            foreach (Reward reward in rewardQuery)
                saveObjectList.Add(Save(reward));
            return saveObjectList;
        }
        public static Reward Load(SaveObject saveObject)
        {
            Type type = Type.GetType(saveObject.TypeName);
            Reward reward = (Reward)Activator.CreateInstance(type, saveObject);
            return reward;
        }
        public static IEnumerable<Reward> LoadQuery(IEnumerable<SaveObject> saveObjectQuery)
        {
            List<Reward> rewardList = new List<Reward>();
            foreach (SaveObject saveObject in saveObjectQuery)
                rewardList.Add(Load(saveObject));
            return rewardList;
        }


        protected Reward(string name)
        {
            Name = name;
        }
        public Reward(SaveObject saveObject)
        {
            Name = saveObject.RewardName;
        }


        private SaveObject Save()
        {
            SaveObject saveObject = new SaveObject();
            saveObject.TypeName = GetType().AssemblyQualifiedName;

            saveObject.RewardName = Name;

            OnSaved(ref saveObject);
            return saveObject;
        }


        protected virtual void OnSaved(ref SaveObject saveObject) { }
        public virtual string GetName() => Name;


        [System.Serializable]
        public sealed class SaveObject
        {
            public string TypeName;
            public string RewardName;
            public int[] IntValues;
        }
    }
}
