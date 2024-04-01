using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDognState
{
    public abstract void Enter(DognStateMachine statemachine);
    public abstract void Update(DognStateMachine statemachine);
    public abstract void Exit(DognStateMachine statemachine);

}
