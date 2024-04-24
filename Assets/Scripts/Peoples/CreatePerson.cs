using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePerson : MonoBehaviour
{
    string filename;
    public TestForSaveingStruct testSave;

    // Start is called before the first frame update
    void Start()
    {
        SaveLoad_Singleton saveLoad_Singleton = new SaveLoad_Singleton();
        
        if (saveLoad_Singleton == null)
            filename = saveLoad_Singleton.save_fileName;

        if (filename != null)
           testSave = saveLoad_Singleton.ReadFromFile("test4");
    }


}
