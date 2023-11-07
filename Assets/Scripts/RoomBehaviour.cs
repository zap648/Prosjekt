using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls; // 0 - Up, 1 - Down, 2 - Right, 3 - Left

    //public bool[] test_status;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    UpdateRoom(test_status);
    //}

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            walls[i].SetActive(!status[i]);
        }
    }
}
