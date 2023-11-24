using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] bool forwards;
    [SerializeField] bool backwards;
    [SerializeField] bool leftwards;
    [SerializeField] bool rightwards;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            forwards = true;
        else if (Input.GetKeyUp(KeyCode.W))
            forwards = false;

        if (Input.GetKeyDown(KeyCode.S))
            backwards = true;
        else if (Input.GetKeyUp(KeyCode.S))
            backwards = false;

        if (Input.GetKeyDown(KeyCode.D))
            rightwards = true;
        else if (Input.GetKeyUp(KeyCode.D))
            rightwards = false;

        if (Input.GetKeyDown(KeyCode.A))
            leftwards = true;
        else if (Input.GetKeyUp(KeyCode.A))
            leftwards = false;

        if (forwards || backwards || leftwards || rightwards)
            Move();
    }

    void Move()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (forwards)
        {
            transform.position = (new Vector2(x, y + speed));
            y = transform.position.y;
        }

        if (backwards)
        {
            transform.position = (new Vector2(x, y - speed));
            y = transform.position.y;
        }

        if (rightwards)
        {
            transform.position = (new Vector2(x + speed, y));
            x = transform.position.x;
        }

        if (leftwards)
        {
            transform.position = (new Vector2(x - speed, y));
            x = transform.position.x;
        }
    }
}
