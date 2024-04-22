using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCityRecruitState : IState
{
    public override void Enter(StateMachine sm)
    {
        Debug.Log("Entered game city recruit State");
    }
    public override void Update(StateMachine sm)
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            sm.SwitchState(sm.mmineState);
        }
    }
    public override void Exit(StateMachine sm)
    {
        Debug.Log("Exited game city recruit State");
    }
}
