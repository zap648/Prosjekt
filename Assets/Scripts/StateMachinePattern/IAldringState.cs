using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAldringState
{
    public abstract void Enter(AldringStateMachine state);
    public abstract void Update(AldringStateMachine state);
    public abstract void Exit(AldringStateMachine state);
}
