using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldringOldState : IAldringState
{
    // has varied length of life, from 1 - 8 days
    public int ageCounter;
    public override void Enter(AldringStateMachine state)
    {
        ageCounter = 0;
        state.age++;
    }

    public override void Update(AldringStateMachine state)
    {
        // every day take a roll
        // accounts for how many days they have been happy
            // 0  - 19% -> 1
            // 20 - 39% -> 2
            // 40 - 59% -> 3
            // 60 - 79% -> 4
            // 80 - 99% -> 5
            // 100%     -> 6/7/8
        // at 8 days, they die no matter what
        if (ageCounter == 8)
        {
            Exit(state);
        }
    }

    public override void Exit(AldringStateMachine state)
    {
        // this person is now deceased. give attribute 'dead'
    }
}
