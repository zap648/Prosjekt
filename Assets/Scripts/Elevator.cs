using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] public ElevatorMachine machine;

    [Header("Elevator info")]
    [SerializeField] public bool hoisting;
    [SerializeField] public bool lowering;
    [SerializeField] public float topHeight;
    [SerializeField] public float bottomHeight;
    [SerializeField] public float speed;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float acceleration;

    public List<GameObject> cargo;
}
