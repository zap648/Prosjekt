using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] public ElevatorMachine machine;

    [Header("Elevator info")]
    [SerializeField] public bool hoisting;
    [SerializeField] public bool lowering;
    [SerializeField] public float topHeight;
    [SerializeField] public float bottomHeight;
    [SerializeField] public bool atTop;
    [SerializeField] public bool atBottom;
    [SerializeField] public float speed;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float acceleration;

    public List<GameObject> cargo;

    // Start is called before the first frame update
    void Awake()
    {
        hoisting = false;
        lowering = false;
        cargo = new List<GameObject>();

        bottomHeight += transform.position.y;
        topHeight += transform.position.y;

        machine = new ElevatorMachine(this);
        machine.Initialize(machine.idleState);
    }

    private void FixedUpdate()
    {
        machine.Update();
    }

    public void Hoist()
    {
        if (!hoisting)
        {
            machine.TransitionTo(machine.hoistState);
        }
    }

    public void Lower()
    {
        if (!lowering)
        {
            machine.TransitionTo(machine.lowerState);
        }
    }
}
