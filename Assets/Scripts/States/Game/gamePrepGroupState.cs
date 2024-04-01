using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePrepGroupState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered prep group State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mprepshopState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited prep group State");
    }
}
