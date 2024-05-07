using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject FamilyPanel;
    [SerializeField] public GameObject HousePanel;
    [SerializeField] public GameObject ExpensePanel;
    [SerializeField] public GameObject SavingsPanel;
    [SerializeField] public GameObject PermitPanel;

    CreatePerson createperson;

    public GameObject FamilyPortrait_prefabs;
    public List<GameObject> FamilyPortrait_list;

    void Start()
    {
        createperson = GetComponent<CreatePerson>();
        if (createperson == null)
        {
            Debug.Log("Couldn't find anything");
        }

        FamilyPortrait_prefabs = Resources.Load<GameObject>("Prefabs/HomeMenuPortrait");

        if (FamilyPortrait_prefabs == null )
        {
            Debug.Log("We didn't find the prefabs");
        }

        FamilyPortrait_list = new List<GameObject>();

        for (int i = 0; i < 8; i++)
        {
            Debug.Log("This is the " + i + " portrait home menu prefab being entered into the LIST");
            FamilyPortrait_list.Add(FamilyPortrait_prefabs);
        }
       
    }

    void Update()
    {
        
    }

    public void DisplayCurrentFamily()
    {
        // found list of family
        if (createperson.list_person.family_list == null)
        {
            Debug.Log("We don't find the list");
            return;
        }

        // make 8 portraits in a list
        List<GameObject> family = new List<GameObject> ();

        family = FamilyPortrait_list;

        int counter = family.Count;
        Debug.Log("There is something in family " + counter);
       
        // instantiate prefabs
        foreach (var f in family)
        {
            // what's wrong is that we are attempting to set the transform of the prefab
            // and not what we have instantiated as the transform
            // which unity does not allow

            //f.SetParent(FamilyPanel.transform, false);
            // Instantiate(f, new Vector3(0,0,0), Quaternion.identity);
            Debug.Log("We instantiated f");
        }

        
        
        //foreach (var f in family)
        //{
        //    FamilyPanel.transform.SetParent (f.transform, false);
        //    // FamilyPanel.transform.SetParent (f.transform, false);
        //}
        // foreach person in list, apply sprite to portrait
        //



        // get image.sprite and apply sprite from familylist persons (getPortrait?)


    }
    public void RemoveCurrentFamily() 
    { 
    
    }

}
