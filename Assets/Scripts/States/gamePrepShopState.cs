using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePrepShopState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered shop State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mhomeendState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited shop State");
    }
}
