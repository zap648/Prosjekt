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

    private void FixedUpdate()
    {
        machine.Update();
    }

    public void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 right = transform.right - transform.forward;
        Vector3 forward = transform.forward + transform.right;

        Vector3 move = right * xMove + forward * zMove;

        controller.Move(move.normalized * speed * Time.deltaTime);
    }

    public void Turn()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 right = transform.right - transform.forward;
        Vector3 forward = transform.forward + transform.right;

        Vector3 move = right * xMove + forward * zMove;

        if (move != Vector3.zero) { mesh.transform.rotation = Quaternion.LookRotation(move, Vector3.up); }
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
