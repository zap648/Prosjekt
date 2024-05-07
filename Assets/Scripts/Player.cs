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
    
    [SerializeField] public List<GameObject> inventory;
    public bool[] move;
    [SerializeField] GameObject interactor;
    [SerializeField] GameObject sprite;
    public float speed;
    public int[] coordinates;

    // Start is called before the first frame update
    void Awake()
    {
        move = new bool[4] { false, false, false, false };
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

        if (xMove != 0)
        {
            if (xMove < 0)
            {
                sprite.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                sprite.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

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

        if (move != Vector3.zero) { interactor.transform.rotation = Quaternion.LookRotation(move, Vector3.up); }
    }
}
