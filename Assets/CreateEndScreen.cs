using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEndScreen : MonoBehaviour
{
    [SerializeField] public GameObject ENDFamilyPanel;
    [SerializeField] public GameObject STARTFamilyPanel;
    [SerializeField] public GameObject PlayerCharacter;

    [SerializeField] public GameObject Portrait_prefab;

    [SerializeField] List<Save_PersonInfo> returnedPeople;

    [SerializeField] List<Person> fam;

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
        Person temp = new Person();
        fam = new List<Person>();
        
        foreach (Save_PersonInfo person in returnedPeople)
        {
            temp.setAllPersonValues(person.getAge(), person.getGender());
            fam.Add(temp);
        }


        addFamilyPortraitsToScene(false);

    }

    // when start next day-button is clicked, this one is called
    public void OpenCreateScreen()
    {
        Debug.Log("The next day screen is opened!");

        // instantiating portrait as child of parent
        addFamilyPortraitsToScene(true);
        

        // remove the family
        // ask family panel to remove family
        PlayerCharacter.GetComponent<Family>();
    }


    /// <summary>
    /// adds portrait_prefabs to Family panel in Canvas
    /// </summary>
    /// <param name="b_startScreen">control to make sure target panel is chosen correctly</param>
    private void addFamilyPortraitsToScene(bool b_startScreen)
    {

        List<GameObject> temp_list = new List<GameObject>();

        GameObject temp_portrait_gameObj;

        for (int i = 0; i < 8; i++)
        {
            temp_list.Add(temp_portrait_gameObj = Instantiate(Portrait_prefab));
        }

        if (b_startScreen)
        {
            foreach (GameObject item in temp_list)
            {
                item.transform.SetParent(STARTFamilyPanel.transform);

                item.transform.position = STARTFamilyPanel.transform.position;
            }
        }
        else
        {
            foreach (GameObject item in temp_list)
            {
                item.transform.SetParent(ENDFamilyPanel.transform);

                item.transform.position = ENDFamilyPanel.transform.position;
            }
        }

        Sprite im = temp_list[0].GetComponentInChildren<Image>().sprite;

        im = fam[0].FindPortrait();
 
    }
}
