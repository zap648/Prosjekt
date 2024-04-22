using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalInfo : MonoBehaviour
{
    [SerializeField] public bool mined;
    [SerializeField] public bool isCoal;
    [SerializeField] public int value;
    
    public CoalInfo(CoalInfo copy)
    {
        mined = copy.mined;
        value = copy.value;
    }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        mined = false;

        if (isCoal)
        {
            value = Random.Range(1, 4);
        }
        else
        {
            value = 0;
        }
    }
}
