using SerializableCallback;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public interface ElevatorState
{
    public void Enter()
    {

    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}

[Serializable]
public class ElevatorMachine
{
    public ElevatorState CurrentState { get; private set; }

    public IdleState idleState;
    public HoistState hoistState;
    public LowerState lowerState;

    public ElevatorMachine(Elevator elevator)
    {
        this.idleState = new IdleState(elevator);
        this.hoistState = new HoistState(elevator);
        this.lowerState = new LowerState(elevator);
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

public class IdleState : ElevatorState
{
    private Elevator elevator;

    public IdleState(Elevator elevator)
    {
        this.elevator = elevator;
    }

    public void Enter()
    {
        Debug.Log("Elevator has entered idle state");
    }

    public void Update()
    {
        // Elevator will remain idle until explicitly told otherwise
    }

    public void Exit()
    {
        Debug.Log("Elevator has exited idle state");
    }
}

public class HoistState : ElevatorState
{
    private Elevator elevator;

    public HoistState(Elevator elevator)
    {
        this.elevator = elevator;
    }

    public void Enter()
    {
        elevator.hoisting = true;
        elevator.speed = elevator.maxSpeed;
        Debug.Log("Elevator has entered hoisting state");
    }

    public void Update()
    {
        elevator.gameObject.transform.position += (Vector3.up * elevator.speed);
        foreach (GameObject coal in elevator.cargo)
            coal.transform.position += (Vector3.up * elevator.speed);

        if (elevator.gameObject.transform.position.y > elevator.topHeight)
        {
            elevator.machine.TransitionTo(elevator.machine.idleState);
        }
    }

    public void Exit()
    {
        elevator.hoisting = false;
        elevator.speed = 0;
        elevator.gameObject.transform.position = new Vector3(elevator.gameObject.transform.position.x, elevator.topHeight, elevator.gameObject.transform.position.z);
        Debug.Log("Elevator has exited hoisting state");
    }
}

public class LowerState : ElevatorState
{
    private Elevator elevator;

    public LowerState(Elevator elevator)
    {
        this.elevator = elevator;
    }

    public void Enter()
    {
        elevator.lowering = true;
        elevator.speed = -elevator.maxSpeed;
        Debug.Log("Elevator has entered lower state");
    }

    public void Update()
    {
        elevator.gameObject.transform.position -= (Vector3.up * elevator.speed);
        foreach (GameObject coal in elevator.cargo)
            coal.transform.position -= (Vector3.up * elevator.speed);

        if (elevator.gameObject.transform.position.y < elevator.bottomHeight)
        {
            elevator.machine.TransitionTo(elevator.machine.idleState);
        }
    }

    public void Exit()
    {
        elevator.lowering = false;
        elevator.speed = 0;
        elevator.gameObject.transform.position = new Vector3(elevator.gameObject.transform.position.x, elevator.bottomHeight, elevator.gameObject.transform.position.z);
        Debug.Log("Elevator has exited lower state");
    }
}
