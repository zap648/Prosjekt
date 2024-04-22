using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameHomeStartState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered home start State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mcityrecruitState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited home start State");
    }
}
