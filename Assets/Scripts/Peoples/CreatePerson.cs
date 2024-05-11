using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatePerson : MonoBehaviour
{
    public TestForSaveingStruct testSave;
    SaveLoad_Singleton saveLoad_Singleton;
    Person person;
    [SerializeField] public PersonList list_person;

    private void Awake()
    {
        saveLoad_Singleton = SaveLoad_Singleton.Instance;
    }

    private void Start()
    {
        list_person = new PersonList();
    }
    public string CreatePersonFOO()
    {
        if (saveLoad_Singleton != null)
        {
            //@NOTE THIS METHOD IS DELETED, USE STREAM READ/WRITE INSTEAD testSave = saveLoad_Singleton.ReadFromFile("test4");
            // Debug.Log("testSave is doneish");
        }
        else
        {
            Debug.Log("saveLoad_Singleton in CreatePerson was null");
        }
        string charName = testSave.charName;
        return charName;
    }

    public void Create()
    {
        // new person
        person = new Person().getAllPersonValues();

        // add to list, a new list is made if there are none. Check that there is space for new fam (max 8)
        if (list_person.family_list == null)
        {
            list_person.setFamily(person);
        }
        else
        {
            if (list_person.family_list.Count <= 7)
            {
                list_person.setFamily(person);
            }
            else
            {
                int i = list_person.family_list.Count;
                Debug.Log("Max family size is 8. Current size is " + i);
            }
        }
        // ask for it to be saved?

    }


}
