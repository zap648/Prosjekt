using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEndScreen : MonoBehaviour
{
    [SerializeField] public GameObject FamilyPanel;
    [SerializeField] public GameObject PlayerCharacter;
    [SerializeField] List<Save_PersonInfo> returnedPeople;

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

        // remove the family
        // ask family panel to remove family
        PlayerCharacter.GetComponent<Family>();
    }
}
