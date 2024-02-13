using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    public abstract void Enter(StateMachine statemachine);
    public abstract void Update(StateMachine statemachine);
    public abstract void Exit(StateMachine statemachine);
}
