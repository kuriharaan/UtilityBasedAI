using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour
{
    public enum WayType
    {
        Escalater,
        Stairs,
    }

    public enum State
    {
        BeforeDecision,
        ApproachToEscalater,
        ApproachToStairs,
        StepUpEscalater,
        StepUpStairs,
        AfterMove,
    }

    CharacterController characterController;
    State state;
    Vector3 dest;

    void Start ()
    {
        state = State.BeforeDecision;
        characterController = GetComponent<CharacterController>();
    }

    static Vector3 escalaterPoint = new Vector3(-2.0f, 0.75f, -1.5f );
    static Vector3 stairsPoint    = new Vector3(1.0f, 0.75f, -1.5f);

    void Update ()
    {
        switch( state )
        {
        case State.BeforeDecision:
        {
            characterController.Move(transform.forward * Time.deltaTime);

            if( -5.0f < transform.position.z )
            {
                var decisionMaking = GetComponent<DecisionMakingBase>();
                decisionMaking.UpdateDecision();

                if( WayType.Escalater == decisionMaking.WayType )
                {
                    state = State.ApproachToEscalater;
                }
                else
                {
                    dest = stairsPoint;
                    dest.x += Random.Range(-1.5f, 1.5f);
                    state = State.ApproachToStairs;
                }
            }
            break;
        }
        case State.ApproachToEscalater:
        {
            characterController.Move((escalaterPoint - transform.position).normalized * Time.deltaTime);
            if (-1.6f < transform.position.z )
            {
                state = State.StepUpEscalater;
            }
            break;
        }
        case State.ApproachToStairs:
        {
            characterController.Move((dest - transform.position).normalized * Time.deltaTime);

            if (-1.6f < transform.position.z)
            {
                state = State.StepUpStairs;
            }

            break;
        }
        case State.StepUpEscalater:
        {
            characterController.Move(transform.forward * Time.deltaTime);


            if (5.0f < transform.position.z)
            {
                state = State.AfterMove;
            }
            break;
        }
        case State.StepUpStairs:
        {
            characterController.Move(transform.forward * Time.deltaTime);

            if (5.0f < transform.position.z)
            {
                state = State.AfterMove;
            }
            break;
        }
        case State.AfterMove:
        {
            characterController.Move(transform.forward * Time.deltaTime);

            if (14.0f < transform.position.z)
            {
                Destroy(gameObject);
            }

            break;
        }
        }

        /*
        if( -1.6f > transform.position.z )
        {
            switch( GetComponent<DecisionMakingBase>().WayType )
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
         */

        if( 14.0f < transform.position.z )
        {
            Destroy(gameObject);
        }
    }
}
