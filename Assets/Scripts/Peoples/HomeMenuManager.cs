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
    CreatePerson createperson;
    void Start()
    {
        // trigger create Persons.cs
        createperson = GetComponent<CreatePerson>();


        // we need to check if this file has ever
        // been opened before. If it has, then there
        // should be a save file
        if (createperson != null)
        {
            // get the saved person list
            Debug.Log(createperson.testSave.charName);
        }
        else
        {
            // make a new person list and save it
            Debug.Log("Couldn't find anything");
        }
    }

    void Update()
    {
        
    }
}
