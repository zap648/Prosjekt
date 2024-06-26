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
        sm.morning.SetActive(true);

        // turns off all of the other times of day
        sm.midday.SetActive(false);
        sm.evening.SetActive(false);
        sm.night.SetActive(false);

        // enable morning activities/places (in ByUI)
        sm.byUI.ActivateCorrectActivities(sm.currentState);
        // set timer for mine to 15hrs
        sm.mineClock = 12;
        sm.compCalender.setCounter();
        // dogncounter
        sm._activityCounter = 0;

        // update day-count and the panel with visible tracking
        sm.byUI.days++;
        sm.byUI.UpdateDayCounter();

        Debug.Log("Good morning nerds!");
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
        // set timer to 9hrs
        sm.mineClock = 8;

        // disable morning activities/places
        sm.byUI.DeactivateCorrectActivities(sm.currentState);

        // close down morning menu
        sm.morning.SetActive(false);
        // switch states
        sm.SwitchState(sm.smMidday);
    }
}
