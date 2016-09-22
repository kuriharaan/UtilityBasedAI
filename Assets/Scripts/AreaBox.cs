using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaBox : MonoBehaviour
{
    List<Agent> agents = new List<Agent>();

    public int NumberOfAgents
    {
        get
        {
            return agents.Count;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        var agent = col.GetComponent<Agent>();
        if( null == agent )
        {
            return;
        }

        agents.Add(agent);
    }

    void OnTriggerExit(Collider col)
    {
        var agent = col.GetComponent<Agent>();
        if( null == agent )
        {
            return;
        }

        agents.Remove(agent);
    }
}
