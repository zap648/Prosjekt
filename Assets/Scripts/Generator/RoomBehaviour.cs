using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls; // 0 - Up, 1 - Right, 2 - Down, 3 - Left
    public GameObject[] spawners;

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
            //walls[i].SetActive(!status[i]);

            for (int j = 0; j < walls[i].transform.childCount; j++)
            {
                if (j == 0)
                    walls[i].transform.GetChild(j).gameObject.SetActive(!status[i]);
                else
                    walls[i].transform.GetChild(j).gameObject.SetActive(status[i]);
            }
        }
    }

    public void GetSpawner()
    {
        
    }
}
