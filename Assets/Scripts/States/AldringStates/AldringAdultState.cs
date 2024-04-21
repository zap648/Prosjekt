using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldringAdultState : IAldringState
{
    // has 32 days
    public int ageCounter;
    public override void Enter(AldringStateMachine state)
    {
        ageCounter = 0;
    }

    public override void Update(AldringStateMachine state)
    {
        if (ageCounter == 32)
        {
            Exit(state);
        }
    }

    public override void Exit(AldringStateMachine state)
    {
        state.SwitchState(state.smOld);

    }
}
