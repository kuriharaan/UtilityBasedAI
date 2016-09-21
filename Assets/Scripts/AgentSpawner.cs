using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField]
    float interval;

    [SerializeField]
    GameObject agentPrefab;


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
            position.x += Random.Range(-1.5f, 2.0f);
            var agent = Instantiate(agentPrefab, position, Quaternion.identity) as GameObject;
            agent.GetComponent<Agent>().wayType = (Agent.WayType)Random.Range(0, 2);


            counter = 0.0f;
        }
    }
}
