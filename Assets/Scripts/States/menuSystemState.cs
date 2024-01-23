using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSystemState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered menu system State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mcharcreateState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited menu system State");
    }
}
