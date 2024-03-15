using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruveElevator : Elevator
{
    // Start is called before the first frame update
    void Start()
    {
        hoisting = false;
        lowering = false;

        machine = new ElevatorMachine(this);
        machine.Initialize(machine.idleState);
    }
}
