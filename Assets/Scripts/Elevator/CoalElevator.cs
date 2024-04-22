using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CoalElevator : Elevator
{
    public GameObject lever;
    public int limit;

    public void PutCoal(GameObject coal)
    {
        if (coal.gameObject.GetComponent<CoalInfo>() && cargo.Count < limit)
        {
            cargo.Add(coal);
            cargo.Last().transform.position = transform.position;
            cargo.Last().SetActive(true);
        }
    }

    public void RemoveCoal(GameObject coal)
    {
        if (cargo.Count != 0)
        {
            cargo.Remove(coal);
        }
        else
        {
            Debug.Log("Coal elevator is empty!");
        }
    }
}
