using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GruveElevator : Elevator
{
    [SerializeField] GameObject gate;

    private void Update()
    {
        machine.Update();

        if (lowering || hoisting)
        {
            gate.SetActive(true);
        }
        else
        {
            gate.SetActive(false);
        }
    }
}
