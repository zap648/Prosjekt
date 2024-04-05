using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognMorningState : IDognState
{
    // always enter this stateon start of 'round'
    public override void Enter(DognStateMachine sm)
    {
        // home menu should be a start-up menu showing todays starting point
        
        // get morning menu 
        // enable morning activities
        // set timer for mine to 15hrs
    }
    public override void Update(DognStateMachine sm)
    {
        // condition counter

        // if condition is met, Exit this state
    }
    public override void Exit(DognStateMachine sm)
    {
        // set timer to 9hrs
        // disable morning activities
        // close down morning menu
    }
}
