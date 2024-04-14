using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognNightState : IDognState
{
    public override void Enter(DognStateMachine sm)
    {
        // get night menu 
        // enable night activities
        sm.byUI.button_home.onClick.AddListener(sm.byUI.GetHomeActivity);
        sm.byUI.button_church.onClick.AddListener(sm.byUI.GetChurchActivity);
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
        sm.byUI.button_home.onClick.RemoveListener(sm.byUI.GetHomeActivity);
        sm.byUI.button_church.onClick.RemoveListener(sm.byUI.GetChurchActivity);
        // close down night menu
    }
}
