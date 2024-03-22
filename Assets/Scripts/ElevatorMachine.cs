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
        Debug.Log($"{elevator.gameObject.name} has entered idle state");
    }

    public void Update()
    {
        // Elevator will remain idle until explicitly told otherwise
    }

    public void Exit()
    {
        Debug.Log($"{elevator.gameObject.name} has exited idle state");
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
        Debug.Log($"{elevator.gameObject.name} has entered hoisting state from a height of {elevator.gameObject.transform.position.y}");
    }

    public void Update()
    {
        if (elevator.gameObject.transform.position.y >= elevator.topHeight)
        {
            Debug.Log($"{elevator.gameObject.name} is at {elevator.gameObject.transform.position.y}, which is higher than {elevator.topHeight}");
            elevator.machine.TransitionTo(elevator.machine.idleState);
        }

        Debug.Log($"{elevator.gameObject.name} at a height of {elevator.transform.position.y} is moving {elevator.speed} upwards");
        elevator.gameObject.transform.position += (Vector3.up * elevator.speed);
        foreach (GameObject cargo in elevator.cargo)
            cargo.transform.position += (Vector3.up * elevator.speed);
    }

    public void Exit()
    {
        elevator.hoisting = false;
        elevator.speed = 0;
        elevator.gameObject.transform.position = new Vector3(elevator.gameObject.transform.position.x, elevator.topHeight, elevator.gameObject.transform.position.z);
        Debug.Log($"{elevator.gameObject.name} has exited hoisting state");
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
        Debug.Log($"{elevator.gameObject.name} has entered lowering state from a height of {elevator.gameObject.transform.position.y}");
    }

    public void Update()
    {
        if (elevator.gameObject.transform.position.y <= elevator.bottomHeight)
        {
            Debug.Log($"{elevator.gameObject.name} is at {elevator.gameObject.transform.position.y}, which is lower than {elevator.bottomHeight}");
            elevator.machine.TransitionTo(elevator.machine.idleState);
        }
        
        elevator.gameObject.transform.position += (Vector3.up * elevator.speed);
        foreach (GameObject cargo in elevator.cargo)
            cargo.transform.position += (Vector3.up * elevator.speed);
    }

    public void Exit()
    {
        elevator.lowering = false;
        elevator.speed = 0;
        elevator.gameObject.transform.position = new Vector3(elevator.gameObject.transform.position.x, elevator.bottomHeight, elevator.gameObject.transform.position.z);
        Debug.Log($"{elevator.gameObject.name} has exited lowering state");
    }
}
