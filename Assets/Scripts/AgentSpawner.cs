using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField]
    float interval;

    [SerializeField]
    GameObject agentPrefab;

    enum DecisionMakingType
    {
        Random,
        Stairs,
    }

    [SerializeField]
    DecisionMakingType decisionMakingType;

    float counter = 0.0f;

    void Start ()
    {
    }

    void Update ()
    {
        counter += Time.deltaTime;
        if( interval <= counter )
        {
            var position = transform.position;
            position.x += Random.Range(-1.5f, 3.0f);
            var agent = Instantiate(agentPrefab, position, Quaternion.identity) as GameObject;

            if( DecisionMakingType.Random  == decisionMakingType )
            {
                agent.AddComponent<DecisionMakingRandom>();
            }
            else
            {
                agent.AddComponent<DecisionMakingUB>();
            }


            counter = 0.0f;
        }
    }
}
