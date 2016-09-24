using UnityEngine;
using System.Collections;

public class GameStatictics : MonoBehaviour
{
    [SerializeField]
    public AreaBox escalaterArea;

    [SerializeField]
    public AreaBox stairsArea;

    [SerializeField]
    public float stairsLength;

    [SerializeField]
    public int escalaterCapacity;

    [SerializeField]
    public int stairsCapacity;

    void Start ()
    {
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 60), escalaterArea.NumberOfAgents.ToString());
    }
}
