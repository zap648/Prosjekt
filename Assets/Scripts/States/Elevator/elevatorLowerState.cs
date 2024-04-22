using UnityEngine;

public class elevatorLowerState : ElevatorState
{
    private Elevator elevator;

    public elevatorLowerState(Elevator elevator)
    {
        this.elevator = elevator;
    }

    public override void Enter()
    {
        elevator.atTop = false;
        elevator.lowering = true;
        elevator.speed = -elevator.maxSpeed;
        Debug.Log($"{elevator.gameObject.name} has entered lowering state from a height of {elevator.gameObject.transform.position.y}");
    }

    public override void Update()
    {
        if (elevator.gameObject.transform.position.y <= elevator.bottomHeight)
        {
            elevator.atBottom = true;
            elevator.machine.TransitionTo(elevator.machine.idleState);
        }

        elevator.gameObject.transform.position += (Vector3.up * elevator.speed);
        foreach (GameObject cargo in elevator.cargo)
            cargo.transform.position += (Vector3.up * elevator.speed);
    }

    public override void Exit()
    {
        elevator.lowering = false;
        elevator.speed = 0;
        elevator.gameObject.transform.position = new Vector3(elevator.gameObject.transform.position.x, elevator.bottomHeight, elevator.gameObject.transform.position.z);
        Debug.Log($"{elevator.gameObject.name} has exited lowering state");
    }
}