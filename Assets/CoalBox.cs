using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CoalBox : Elevator
{
    public GameObject lever;
    public int limit;

    // Start is called before the first frame update
    void Start()
    {
        hoisting = false;
        lowering = false;
        cargo = new List<GameObject>();
        machine = new ElevatorMachine(this);
        machine.Initialize(machine.idleState);
    }

    private void Update()
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

    public void PutCoal(GameObject coal)
    {
        if (coal.gameObject.GetComponent<CoalInfo>() && cargo.Count < limit)
        {
            cargo.Add(coal);
            cargo.Last().transform.position = transform.position;
            cargo.Last().SetActive(true);
        }
    }
}
