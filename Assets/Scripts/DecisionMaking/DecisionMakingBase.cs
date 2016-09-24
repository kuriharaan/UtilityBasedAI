using UnityEngine;
using System.Collections;

public class DecisionMakingBase : MonoBehaviour
{

    public Agent.WayType WayType
    {
        get;
        protected set;
    }

    public virtual void UpdateDecision() { }
}
