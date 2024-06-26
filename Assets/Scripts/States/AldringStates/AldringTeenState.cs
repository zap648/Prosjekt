using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldringTeenState : IAldringState
{
    // has 6 days
    public int ageCounter;
    public override void Enter(AldringStateMachine state)
    {
        ageCounter = 0;
        state.age++;
    }
    public override void Update(AldringStateMachine state)
    {
        if (ageCounter >= 6)
        {
            Exit(state);
        }
    }

    public override void Exit(AldringStateMachine state)
    {
        state.SwitchState(state.smYAdult);
    }

}
