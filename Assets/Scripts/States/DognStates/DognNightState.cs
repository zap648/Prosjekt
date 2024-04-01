using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognNightState : IDognState
{
    public override void Enter(DognStateMachine sm)
    {
        // get night menu 
        // enable night activities
        // set timer for mine to 0hrs
    }
    public override void Update(DognStateMachine sm)
    {
        // condition counter

        // if condition is met, Exit this state
    }
    public override void Exit(DognStateMachine sm)
    {
        // set timer to 0hrs
        // disable night activities
        // close down night menu
    }
}
