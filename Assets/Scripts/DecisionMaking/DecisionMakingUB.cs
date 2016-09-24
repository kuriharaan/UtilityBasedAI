using UnityEngine;
using System.Collections;

public class DecisionMakingUB : DecisionMakingBase
{
    public override void UpdateDecision()
    {
        float escalaterScore = CalcEscalaterScore();
        float stairsScore = CalcStairsScore();
        if (escalaterScore < stairsScore)
        {
            WayType = Agent.WayType.Stairs;
        }
        else
        {
            WayType = Agent.WayType.Escalater;
        }
    }

    float CalcEscalaterScore()
    {
        var statictics = GameObject.FindObjectOfType<GameStatictics>();
        float crowdedness = (float)statictics.escalaterArea.NumberOfAgents / (float)statictics.escalaterCapacity;
        float score = 1.0f - Mathf.Min(crowdedness, 1.0f);
        return score * score;
    }

    float CalcStairsScore()
    {
        var statictics = GameObject.FindObjectOfType<GameStatictics>();
        float crowdedness = (float)statictics.stairsArea.NumberOfAgents / (float)statictics.stairsCapacity;
        float hardships = Mathf.Min(1.0f, statictics.stairsLength / statictics.stairsLengthMax );
        float score = 1.0f - Mathf.Min(crowdedness, 1.0f);
        return ((score * score) + (1.0f - hardships)) * 0.5f;
    }
}
