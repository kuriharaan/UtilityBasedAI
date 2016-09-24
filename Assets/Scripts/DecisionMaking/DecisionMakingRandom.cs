using UnityEngine;
using System.Collections;

public class DecisionMakingRandom : DecisionMakingBase
{
    public override void UpdateDecision()
    {
        WayType = (Agent.WayType)Random.Range(0, System.Enum.GetNames(typeof(Agent.WayType)).Length);
    }
}
