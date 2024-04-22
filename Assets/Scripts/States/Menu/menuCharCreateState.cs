using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCharCreateState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered menu char creation State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mhomestartState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited menu char creation State");
    }
}
