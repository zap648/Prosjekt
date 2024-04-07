using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalInfo : MonoBehaviour
{
    [SerializeField] bool mined;
    [SerializeField] int value;

    // Start is called before the first frame update
    void Start()
    {
        mined = false;
        value = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
