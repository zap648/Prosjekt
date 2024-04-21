using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject FamilyPanel;
    [SerializeField] public GameObject HousePanel;
    [SerializeField] public GameObject ExpensePanel;
    [SerializeField] public GameObject SavingsPanel;
    [SerializeField] public GameObject PermitPanel;

    string filename = "Test";

    void Start()
    {
        // we need to check if this file has ever
        // been opened before. If it has, then there
        // should be a save file
        if (true)
        {
            // get the saved person list
        }
        else
        {
            // make a new person list and save it
        }
    }

    void Update()
    {
        
    }
}
