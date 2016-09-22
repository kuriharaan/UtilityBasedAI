using UnityEngine;
using System.Collections;

public class DecisionMakingRandom : DecisionMakingBase
{
    void Start ()
    {
        WayType = (Agent.WayType)Random.Range(0, System.Enum.GetNames(typeof(Agent.WayType)).Length);
    }
}
