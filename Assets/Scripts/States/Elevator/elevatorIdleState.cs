using UnityEngine;

public class elevatorIdleState : ElevatorState
{
    private Elevator elevator;

    public elevatorIdleState(Elevator elevator)
    {
        this.elevator = elevator;
    }

    public override void Enter()
    {
        Debug.Log($"{elevator.gameObject.name} has entered idle state");
    }

    public override void Update()
    {
        // Elevator will remain idle until explicitly told otherwise
    }

    public override void Exit()
    {
        Debug.Log($"{elevator.gameObject.name} has exited idle state");
    }
}
