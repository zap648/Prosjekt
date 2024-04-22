using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePerson : MonoBehaviour
{
    public TestForSaveingStruct testSave;
    SaveLoad_Singleton saveLoad_Singleton;

    private void Awake()
    {
        saveLoad_Singleton = SaveLoad_Singleton.Instance;
    }

    public string CreatePersonFOO()
    {
        if (saveLoad_Singleton != null)
        {
            testSave = saveLoad_Singleton.ReadFromFile("test4");
            // Debug.Log("testSave is doneish");
        }
        else
        {
            Debug.Log("saveLoad_Singleton in CreatePerson was null");
        }
        string charName = testSave.charName;
        return charName;
    }



}
