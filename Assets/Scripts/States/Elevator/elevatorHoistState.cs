using UnityEngine;

public class elevatorHoistState : ElevatorState
{
    private Elevator elevator;

    public elevatorHoistState(Elevator elevator)
    {
        this.elevator = elevator;
    }

    public override void Enter()
    {
        elevator.atBottom = false;
        elevator.hoisting = true;
        elevator.speed = elevator.maxSpeed;
        Debug.Log($"{elevator.gameObject.name} has entered hoisting state from a height of {elevator.gameObject.transform.position.y}");
    }

    public override void Update()
    {
        if (elevator.gameObject.transform.position.y >= elevator.topHeight)
        {
            elevator.atTop = true;
            elevator.machine.TransitionTo(elevator.machine.idleState);
        }

        elevator.gameObject.transform.position += (Vector3.up * elevator.speed);
        foreach (GameObject cargo in elevator.cargo)
            cargo.transform.position += (Vector3.up * elevator.speed);
    }

    public override void Exit()
    {
        elevator.hoisting = false;
        elevator.speed = 0;
        elevator.gameObject.transform.position = new Vector3(elevator.gameObject.transform.position.x, elevator.topHeight, elevator.gameObject.transform.position.z);
        Debug.Log($"{elevator.gameObject.name} has exited hoisting state");
    }
}