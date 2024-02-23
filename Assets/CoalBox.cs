using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoalBox : MonoBehaviour
{
    [SerializeField] bool hoisting;
    [SerializeField] bool lowering;
    public List<GameObject> last;
    public int limit;

    // Start is called before the first frame update
    void Start()
    {
        last = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hoisting)
        {
            Hoist();
        }

        if (lowering)
        {
            Lower();
        }
    }

    void Hoist()
    {
        transform.position += Vector3.up * Time.deltaTime;
        foreach (GameObject coal in last)
            coal.transform.position += Vector3.up * Time.deltaTime;

        if (transform.position.y > 15.0f)
        {
            hoisting = false;
            lowering = true;
        }
    }

    void Lower()
    {
        transform.position -= Vector3.up * Time.deltaTime;
        foreach (GameObject coal in last)
            coal.transform.position -= Vector3.up * Time.deltaTime;

        if (transform.position.y <= 0.0f)
        {
            transform.position.Set(transform.position.x, 0.0f, transform.position.z);
            lowering = false;
        }
    }

    public void PutCoal(GameObject coal)
    {
        if (coal.gameObject.GetComponent<CoalInfo>() && last.Count < limit)
        {
            last.Add(coal);
            last.Last().transform.position = transform.position;
            last.Last().SetActive(true);
        }
    }
}
