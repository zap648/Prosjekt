using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMachine machine;

    public CharacterController controller;

    [SerializeField] bool[] move; // 0 - forwards, 1 - backwards, 2 - right, 3 - left
    [SerializeField] bool mine;

    [SerializeField] bool coalMinable;
    [SerializeField] bool bearable;
    [SerializeField] GameObject mineObject;
    
    [SerializeField] public List<GameObject> inventory;
    [SerializeField] GameObject mesh;
    public float speed;
    public int[] coordinates;

    // Start is called before the first frame update
    void Awake()
    {
        move = new bool[4];
        inventory = new List<GameObject>();
        machine = new PlayerMachine(this);
        machine.Initialize(machine.walkState);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        machine.Update();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { Use(); }

        if (Input.GetKeyDown(KeyCode.E)) { Drop(); }
    }

    public void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right - transform.forward) * xMove + (transform.forward + transform.right) * zMove;

        controller.Move(move * speed * Time.deltaTime);
    }

    public void Turn()
    {
        //if (move[0] || move[1] || move[2] || move[3])
        //{
        //    float x = transform.position.x;
        //    float y = transform.position.z;

        //    if (move[0])
        //    {
        //        x += speed;
        //        y += speed;
        //    }

        //    if (move[1])
        //    {
        //        x -= speed;
        //        y -= speed;
        //    }

        //    if (move[2])
        //    {
        //        x += speed;
        //        y -= speed;
        //    }

        //    if (move[3])
        //    {
        //        x -= speed;
        //        y += speed;
        //    }

        //    Vector3 movement = new Vector3(x, transform.position.y, y) - transform.position;
        //    mesh.transform.rotation = Quaternion.Slerp(mesh.transform.rotation, Quaternion.LookRotation(movement, transform.up), 0.1f);
        //}
    }

    void Use()
    {
        if (coalMinable)
        {
            Debug.Log($"Mined {mineObject.name}");
            PutInInventory();
            mineObject.SetActive(false);
            coalMinable = false;
            mineObject = null;
        }
        else if (bearable)
        {
            if (mineObject.GetComponent<CoalElevator>() != null)
            {
                if (mineObject.GetComponent<CoalElevator>().atBottom)
                {
                    mineObject.GetComponent<CoalElevator>().Hoist();
                }
                else if (mineObject.GetComponent<CoalElevator>().atTop)
                {
                    mineObject.GetComponent<CoalElevator>().Lower();
                }
            }
            else if (mineObject.GetComponent<GruveElevator>() != null)
            {
                if (mineObject.GetComponent<GruveElevator>().atBottom)
                {
                    mineObject.GetComponent<GruveElevator>().cargo.Add(gameObject);
                    mineObject.GetComponent<GruveElevator>().Hoist();
                }
                else if (mineObject.GetComponent<GruveElevator>().atTop)
                {
                    mineObject.GetComponent<GruveElevator>().cargo.Add(gameObject);
                    mineObject.GetComponent<GruveElevator>().Lower();
                }
            }
        }
    }

    void Drop()
    {
        if (inventory.Count > 0)
        {
            if (bearable && mineObject.GetComponent<CoalElevator>().cargo.Count < mineObject.GetComponent<CoalElevator>().limit)
            {
                mineObject.GetComponent<CoalElevator>().PutCoal(inventory.Last());
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
