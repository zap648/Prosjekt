using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldringBabyState : IAldringState
{
    // has 2 days
    public int ageCounter;
    public override void Enter(AldringStateMachine state)
    {
        ageCounter = 0;
        state.age = 0;
    }
    public override void Update(AldringStateMachine state)
    {
        if (ageCounter >= 2)
        {
            Exit(state);    
        }

    }

    public override void Exit(AldringStateMachine state)
    {
        state.SwitchState(state.smChild);
    }

}
