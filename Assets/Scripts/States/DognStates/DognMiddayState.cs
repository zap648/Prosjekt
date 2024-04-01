using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognMiddayState : IDognState
{
    // enter this state when returning to city menu
    public override void Enter(DognStateMachine sm)
    {
        // get midday menu 
        // enable midday activities
        // set timer for mine to 9hrs
    }
    public override void Update(DognStateMachine sm)
    {
        // condition counter

        // if condition is met, Exit this state
    }
    public override void Exit(DognStateMachine sm)
    {
        // set timer to 3hrs
        // disable midday activities
        // close down midday menu
    }
}
