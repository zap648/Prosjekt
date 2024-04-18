using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognEveningState : IDognState
{
    public override void Enter(DognStateMachine sm)
    {
        // get evening menu 
        // enable evening activities
        sm.evening.SetActive(true);
        sm.byUI.ActivateCorrectActivities(sm.currentState);
        sm.mineClock = 4;
        sm._activityCounter = 0;
        // set timer for mine to 3hrs
    }
    public override void Update(DognStateMachine sm)
    {
        // condition counter

        // if condition is met, Exit this state
        if (sm._activityCounter == 2)
        {
            Exit(sm);
        }
    }
    public override void Exit(DognStateMachine sm)
    {
        // set timer to 0hrs
        // disable evening activities
        sm.mineClock = 0;
        // disable morning activities/places
        sm.byUI.DeactivateCorrectActivities(sm.currentState);

        // close down morning menu
        sm.evening.SetActive(false);
        // switch states
        sm.SwitchState(sm.smNight);
        // close down evening menu
    }
}
