using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameHomeEndState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered home end State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.msystemState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited home end State");
    }
}
