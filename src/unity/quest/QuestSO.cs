using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class QuestSO : ScriptableObject
    {
        [SerializeField] private string ID;
        [SerializeField] private string Name;
        [SerializeField, TextArea(3, 10)] private string Description;
        [SerializeField] private QuestType QuestType;
        [SerializeField] private Sprite Icon;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQuest Create()
        {
            IconRegistry.Current.Register(ID, Icon);
            DescriptionRegistry.Current.Register(ID, Description);
            return OnCreate(ID, Name, QuestType);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="questType"></param>
        /// <returns></returns>
        protected abstract IQuest OnCreate(string id, string name, QuestType questType);
    }
}
