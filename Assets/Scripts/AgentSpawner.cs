using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField]
    float interval;

    [SerializeField]
    float intervalRange;

    [SerializeField]
    GameObject agentPrefab;

    enum DecisionMakingType
    {
        Random,
        SimpleUtilityBased,
    }

    [SerializeField]
    DecisionMakingType decisionMakingType;

    float counter = 0.0f;

    void Start ()
    {
        ResetCounter();
    }

    void ResetCounter()
    {
        counter = interval + Random.Range(-intervalRange, intervalRange);
    }

    void Update ()
    {
        counter -= Time.deltaTime;
        if( 0.0f > counter )
        {
            ResetCounter();
            var position = transform.position;
            position.x += Random.Range(-1.0f, 1.0f);
            var agent = Instantiate(agentPrefab, position, Quaternion.identity) as GameObject;

            if( DecisionMakingType.Random  == decisionMakingType )
            {
                agent.AddComponent<DecisionMakingRandom>();
            }
            else
            {
                agent.AddComponent<DecisionMakingUB>();
            }
        }
    }
}
