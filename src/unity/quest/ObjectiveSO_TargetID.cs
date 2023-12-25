using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class ObjectiveSO_TargetID : ObjectiveSO
    {
        [SerializeField] protected string TargetID;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override IObjective OnCreate()
        {
            return new Objective_TargetID(ID, Name, TargetID);
        }
    }
}
