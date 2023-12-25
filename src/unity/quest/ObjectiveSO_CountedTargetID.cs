using UnityEngine;
using WWWisky.quests.core;

namespace WWWisky.quests.unity
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class ObjectiveSO_CountedTargetID : ObjectiveSO_TargetID
    {
        [SerializeField] private int TargetAmount;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IObjective OnCreate()
        {
            return new Objective_CountedTargetID(ID, Name, TargetID, TargetAmount);
        }
    }
}
