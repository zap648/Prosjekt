using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad_Singleton : MonoBehaviour
{
    private static SaveLoad_Singleton _instance;

    public string save_fileName = "TestingPathName";
    [SerializeField] public SO_saveload LikeSub;
    public TestForSaveingStruct ThisThing;

    public static SaveLoad_Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                SetUpInstance();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private static void SetUpInstance()
    {
        _instance = FindObjectOfType<SaveLoad_Singleton>();

        if (_instance == null)
        {
            GameObject gobj = new GameObject();
            gobj.name = "SaveLoad Singleton";
            _instance = gobj.AddComponent<SaveLoad_Singleton>();
            DontDestroyOnLoad(gobj);
        }
    }


    public void WriteToFile(string filename)
    {
        ThisThing.naming("Darling"); // struct put info in itself, for example use. In this example it is "Darling"

        if (!Directory.Exists(save_fileName))
        {
            Directory.CreateDirectory(save_fileName);
        }
        
        BinaryFormatter binaryConverter = new BinaryFormatter();

        FileStream saveFilePath = File.Create(save_fileName + "/" + "test4" + ".bin");

        binaryConverter.Serialize(saveFilePath, ThisThing);

        saveFilePath.Close();
    }

    public TestForSaveingStruct ReadFromFile(string filename)
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();

        FileStream saveFile = File.Open(save_fileName + "/" + "test4" + ".bin", FileMode.Open);

        TestForSaveingStruct loadData = (TestForSaveingStruct) binaryConverter.Deserialize(saveFile);

        saveFile.Close();

        return loadData;
    }
}
