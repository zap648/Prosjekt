using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] bool forwards;
    [SerializeField] bool backwards;
    [SerializeField] bool leftwards;
    [SerializeField] bool rightwards;
    [SerializeField] bool mine;
    [SerializeField] bool coalMinable;
    [SerializeField] CoalGenerator coalGenerator;
    [SerializeField] GameObject coalObject;
    [SerializeField] List<GameObject> inventory;
    [SerializeField] GameObject mesh;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();


        if (forwards || backwards || leftwards || rightwards)
            Move();

        if (mine)
            Mine();
    }

    void GetInput()
    {
        // Good lord this input code is awful
        if (Input.GetKeyDown(KeyCode.W))
        {
            forwards = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            forwards = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            backwards = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            backwards = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rightwards = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rightwards = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            leftwards = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            leftwards = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mine = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            mine = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Drop();
        }
    }

    void Move()
    {
        float x = transform.position.x;
        float y = transform.position.z;

        if (forwards)
        {
            x += speed * Time.deltaTime;
            y += speed * Time.deltaTime;
        }

        if (backwards)
        {
            x -= speed * Time.deltaTime;
            y -= speed * Time.deltaTime;
        }

        if (rightwards)
        {
            x += speed * Time.deltaTime;
            y -= speed * Time.deltaTime;
        }

        if (leftwards)
        {
            x -= speed * Time.deltaTime;
            y += speed * Time.deltaTime;
        }

        Vector3 position = new Vector3(x, transform.position.y, y);
        Vector3 movement = position - transform.position;

        GetComponent<Rigidbody>().MovePosition(position);
        mesh.transform.rotation = Quaternion.Slerp(mesh.transform.rotation, Quaternion.LookRotation(movement, transform.up), 0.01f);
    }

    void Mine()
    {
        if (coalMinable)
        {
            Debug.Log($"Mined {coalObject.name}");
            PutInInventory();
            coalObject.SetActive(false);
            coalMinable = false;
            coalObject = null;
            coalMinable = false;
        }
    }

    void Drop()
    {
        if (inventory.Count > 0)
        {
            inventory.Last().SetActive(true);
            inventory.Last().transform.position = transform.position + mesh.transform.forward * 2;
            Debug.Log($"Dropped {inventory.Last().name}");
            inventory.Remove(inventory.Last());
        }
    }

    void PutInInventory()
    {
        inventory.Add(coalObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var coal in coalGenerator.coals)
        if (coal == collision.gameObject)
        {
            coalMinable = true;
            coalObject = collision.gameObject;
        }
        Debug.Log($"About to mine this fine piece of {collision.gameObject.name}");
    }

    private void OnCollisionExit(Collision collision)
    {
        coalMinable = false;
        coalObject = null;
        Debug.Log($"Ah... it seems the {collision.gameObject.name} is gone");
    }
}
