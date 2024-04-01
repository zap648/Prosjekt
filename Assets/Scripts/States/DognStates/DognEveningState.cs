using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognEveningState : IDognState
{
    public override void Enter(DognStateMachine sm)
    {
        // get evening menu 
        // enable evening activities
        // set timer for mine to 3hrs
    }
    public override void Update(DognStateMachine sm)
    {
        // condition counter

        // if condition is met, Exit this state
    }
    public override void Exit(DognStateMachine sm)
    {
        // set timer to 0hrs
        // disable evening activities
        // close down evening menu
    }
}
