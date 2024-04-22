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

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
