using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEndScreen : MonoBehaviour
{
    [SerializeField] public GameObject ENDFamilyPanel;
    [SerializeField] public GameObject STARTFamilyPanel;
    [SerializeField] public GameObject PlayerCharacter;

    [SerializeField] public GameObject Portrait_prefab;

    [SerializeField] List<Save_PersonInfo> returnedPeople;

    Person person;

    // when conclude day-button is clicked, this one is called
    public void OpenEndScreen()
    {
        Debug.Log("Conclude day screen is opened!");

        // we need the family.cs (Component) in PC
        // ask family panel to load family
        SaveLoad_Singleton saveLoad = PlayerCharacter.GetComponent<Family>().instance_ask;
        List<Save_PersonInfo> personInfos = new List<Save_PersonInfo>();

        personInfos = PlayerCharacter.GetComponent<Family>().persons;

        saveLoad.BinaryReader_SavePerson(personInfos, true);

        returnedPeople = saveLoad.BinaryReader_LoadPerson();

    }

    // when start next day-button is clicked, this one is called
    public void OpenCreateScreen()
    {
        Debug.Log("The next day screen is opened!");

        //// instantiating portrait as child of parent

        List<GameObject> temp_list = new List<GameObject>();

        GameObject thing;
        //GameObject thing = Instantiate(Portrait_prefab);

        for (int i = 0; i < 8; i++)
        {
            temp_list.Add(thing = Instantiate(Portrait_prefab));
        }

        foreach (GameObject item in temp_list)
        {
            item.transform.SetParent(STARTFamilyPanel.transform);

            item.transform.position = STARTFamilyPanel.transform.position;
            
        }
        

        // remove the family
        // ask family panel to remove family
        PlayerCharacter.GetComponent<Family>();
    }
}
