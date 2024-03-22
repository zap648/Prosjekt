using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Dette er *ALTFOR* mange variablar. Me *MÅ* fjerne rørsleboolane xD
    [SerializeField] bool forwards;
    [SerializeField] bool backwards;
    [SerializeField] bool leftwards;
    [SerializeField] bool rightwards;
    [SerializeField] bool mine;

    [SerializeField] bool coalMinable;
    [SerializeField] bool bearable;
    [SerializeField] GameObject mineObject;
    
    [SerializeField] List<GameObject> inventory;
    [SerializeField] GameObject mesh;
    public float speed;
    public int[] coordinates;

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
        if (Input.GetKeyDown(KeyCode.W)) { forwards = true; }
        else if (Input.GetKeyUp(KeyCode.W)) { forwards = false; }

        if (Input.GetKeyDown(KeyCode.S)) { backwards = true; }
        else if (Input.GetKeyUp(KeyCode.S)) { backwards = false; }

        if (Input.GetKeyDown(KeyCode.D)) { rightwards = true; }
        else if (Input.GetKeyUp(KeyCode.D)) { rightwards = false; }

        if (Input.GetKeyDown(KeyCode.A)) { leftwards = true; }
        else if (Input.GetKeyUp(KeyCode.A)) { leftwards = false; }

        if (Input.GetKeyDown(KeyCode.Space)) { mine = true; }
        else if (Input.GetKeyUp(KeyCode.Space)) { mine = false; }

        if (Input.GetKeyDown(KeyCode.E)) { Drop(); }
    }

    void Move()
    {
        float x = transform.position.x;
        float y = transform.position.z;

        if (forwards)
        {
            x += speed;
            y += speed;
        }

        if (backwards)
        {
            x -= speed;
            y -= speed;
        }

        if (rightwards)
        {
            x += speed;
            y -= speed;
        }

        if (leftwards)
        {
            x -= speed;
            y += speed;
        }

        Vector3 position = new Vector3(x, transform.position.y, y);
        Vector3 movement = position - transform.position;

        GetComponent<Rigidbody>().MovePosition(position);
        mesh.transform.rotation = Quaternion.Slerp(mesh.transform.rotation, Quaternion.LookRotation(movement, transform.up), 0.1f);
    }

    void Mine()
    {
        if (coalMinable)
        {
            Debug.Log($"Mined {mineObject.name}");
            PutInInventory();
            mineObject.SetActive(false);
            coalMinable = false;
            mineObject = null;
            coalMinable = false;
        }
        else if (bearable)
        {
            if (mineObject.GetComponent<CoalBox>() != null)
            {
                mineObject.GetComponent<CoalBox>().Hoist();
            }
            else if (mineObject.GetComponent<GruveElevator>() != null)
            {
                mineObject.GetComponent<GruveElevator>().Hoist();
            }
        }
    }

    void Drop()
    {
        if (inventory.Count > 0)
        {
            if (bearable && mineObject.GetComponent<CoalBox>().cargo.Count < mineObject.GetComponent<CoalBox>().limit)
            {
                mineObject.GetComponent<CoalBox>().PutCoal(inventory.Last());
                Debug.Log($"Put {mineObject} in coal box");
                inventory.Remove(inventory.Last());
            }
            else
            {
                inventory.Last().SetActive(true);
                inventory.Last().transform.position = transform.position + mesh.transform.forward * 2;
                Debug.Log($"Dropped {inventory.Last().name}");
                inventory.Remove(inventory.Last());
            }
        }
        else
        {
            Debug.Log("You have no coal to drop");
        }
    }

    void PutInInventory()
    {
        inventory.Add(mineObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CoalInfo>() && !bearable)
        {
            coalMinable = true;
            mineObject = collision.gameObject;
            Debug.Log($"About to mine this fine piece of {collision.gameObject.name}");
        }
        else if (collision.gameObject.GetComponent<Elevator>())
        {
            bearable = true;
            mineObject = collision.gameObject;
            Debug.Log($"About to heave the {collision.gameObject.name}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        coalMinable = false;
        mineObject = null;
        bearable = false;
        Debug.Log($"Ah... it seems the {collision.gameObject.name} is gone");
    }
}
