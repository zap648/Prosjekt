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
        sm.midday.SetActive(true);
        sm.byUI.ActivateCorrectActivities(sm.currentState);
        sm.mineClock = 8;
        sm._activityCounter = 0;
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
        // set timer to 3hrs
        // disable midday activities
        // close down midday menu
        sm.mineClock = 4;
        // disable morning activities/places
        sm.byUI.DeactivateCorrectActivities(sm.currentState);

        // close down morning menu
        sm.midday.SetActive(false);
        // switch states
        sm.SwitchState(sm.smEvening);
    }
}
