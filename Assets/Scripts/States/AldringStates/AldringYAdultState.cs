using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldringYAdultState : IAldringState
{
    // has 2 days
    public int ageCounter;
    // may move out on one of those days, must move out at day 3
    public override void Enter(AldringStateMachine state)
    {
        ageCounter = 0;
        state.age++;
    }

    public override void Update(AldringStateMachine state)
    {
        // every concluded day a random roll is taken, it should account for
        // things life how much they like PC, how happy they are, and if they have a job
        // then add if it is the 1st, 2nd, or 3rd day. 
            // 1st day - 20% chance
            // 2nd day - 50% chance
            // 3rd day - guaranteed moved out
        if (ageCounter == 3)
        {
            Exit(state);
        }
    }
    public override void Exit(AldringStateMachine state)
    {
        state.SwitchState(state.smAdult);
    }

}
