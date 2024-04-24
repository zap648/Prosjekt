using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class DognNightState : IDognState
{
    public override void Enter(DognStateMachine sm)
    {
        // get night menu 
        // enable night activities
        sm.night.SetActive(true);
        sm.byUI.ActivateCorrectActivities(sm.currentState);
        sm.mineClock = 0;
        sm._activityCounter = 0;
        // set timer for mine to 0hrs
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
        // disable night activities
        sm.mineClock = 0;
        // disable morning activities/places
        sm.byUI.DeactivateCorrectActivities(sm.currentState);

        // close down morning menu
        sm.night.SetActive(false);
        // switch states
        
        // switch to morning state
        sm.SwitchState(sm.smMorning);
    }
}
