using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public InputController inputController;

    public enum States
    {
        freeMovement,
        noMovement
    }
    public States currentState;

    void Awake()
    {
        currentState = States.freeMovement;
    }

    void Update()
    {
        switch (currentState)
        {
            case States.freeMovement:
                inputController.enabled = true;
                break;
            case States.noMovement:
                inputController.enabled = false;
                break;
            default:
                inputController.enabled = true;
                break;
        }
    }

    public void SetState(States state)
    {
        currentState = state;
    }
}
