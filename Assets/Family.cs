using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour
{
    public Save_PersonInfo person;
    public List<Save_PersonInfo> persons;

    public SaveLoad_Singleton instance_ask;

    private void Start()
    {
        instance_ask = GetComponent<SaveLoad_Singleton>();

        if (instance_ask == null)
        {
            instance_ask = SaveLoad_Singleton.Instance;
        }

        person = new Save_PersonInfo();
        persons = new List<Save_PersonInfo>();

        person.setInfo(0, 4);
        persons.Add(person);
        person.setInfo(1, 9);
        persons.Add(person);

        string peeps = persons[1].getAge().ToString();


        Debug.Log("Family.Start: " + peeps);
    }
}
