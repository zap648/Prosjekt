using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMineState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered mine State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mprepgroupState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited mine State");
    }
}
