using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalBox : MonoBehaviour
{
    [SerializeField] bool hoisting;
    [SerializeField] bool lowering;
    [SerializeField] List<CoalInfo> last;

    // Start is called before the first frame update
    void Start()
    {
        last = new List<CoalInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hoisting)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }

        if (lowering)
        {
            transform.position -= Vector3.up * Time.deltaTime;
        }
    }
}
