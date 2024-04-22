using System;
using UnityEngine;

[Serializable]
public class ElevatorMachine
{
    public ElevatorState CurrentState { get; private set; }

    public elevatorIdleState idleState;
    public elevatorHoistState hoistState;
    public elevatorLowerState lowerState;

    public ElevatorMachine(Elevator elevator)
    {
        this.idleState = new elevatorIdleState(elevator);
        this.hoistState = new elevatorHoistState(elevator);
        this.lowerState = new elevatorLowerState(elevator);
    }

    public void Initialize(ElevatorState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void TransitionTo(ElevatorState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}
