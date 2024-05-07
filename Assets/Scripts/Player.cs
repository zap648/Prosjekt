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
    [SerializeField] GameObject interactor;
    [SerializeField] GameObject mesh;
    public float speed;
    public int[] coordinates;

    // Start is called before the first frame update
    void Awake()
    {
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

        if (move != Vector3.zero) { interactor.transform.rotation = Quaternion.LookRotation(move, Vector3.up); }
    }
}
