using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CoalBox : Elevator
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
}
