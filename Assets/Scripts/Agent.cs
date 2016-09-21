using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour
{
    CharacterController characterController;

    public enum WayType
    {
        Escalater,
        Stairs,
    }

    public WayType wayType = WayType.Escalater;

    void Start ()
    {
        characterController = GetComponent<CharacterController>();
    }

    static Vector3 escalaterPoint = new Vector3(-2.0f, 0.0f, -1.5f );

    void Update ()
    {
        if( -1.6f > transform.position.z )
        {
            switch( wayType )
            {
            case WayType.Escalater:
            {
                characterController.Move((escalaterPoint - transform.position).normalized * Time.deltaTime);
                break;
            }
            case WayType.Stairs:
            {
                if (-0.5 > transform.position.x )
                {
                    var dest = transform.position;
                    dest.x = -0.4f;
                    characterController.Move((dest - transform.position).normalized * Time.deltaTime);
                }
                else
                {
                    characterController.Move(transform.forward * Time.deltaTime);
                }
                break;
            }
            }
        }
        else
        {
            characterController.Move(transform.forward * Time.deltaTime);
        }

        if( 14.0f < transform.position.z )
        {
            Destroy(gameObject);
        }
    }
}
