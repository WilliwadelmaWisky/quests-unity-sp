using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class StageSO : ScriptableObject
    {
        [SerializeField] private ObjectiveSO[] Objectives;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stage Create()
        {
            Stage stage = new Stage();
            foreach (ObjectiveSO objectiveSO in Objectives)
                stage.Add(objectiveSO.Create());

            return stage;
        }
    }
}
