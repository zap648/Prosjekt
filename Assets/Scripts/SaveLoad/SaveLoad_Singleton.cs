using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Unity.VisualScripting;

public class SaveLoad_Singleton : MonoBehaviour
{   
    // singleton _instance
    private static SaveLoad_Singleton _instance;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public string save_fileName = "TestingPathName";
    [SerializeField] public SO_saveload LikeSub;
    public TestForSaveingStruct ThisThing;
    public Save_PersonInfo PersonInfo;

    string path = "TestingPathName/personFile.bin";

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    // singleton methods

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

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // using BinaryFormatter
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

    public Save_PersonInfo LoadPerson()
    {
        BinaryFormatter bConverter = new BinaryFormatter();

        FileStream saveFilePath = File.Open(save_fileName + "/" + "personFile" + ".bin", FileMode.Open);
        
        Save_PersonInfo loadData = (Save_PersonInfo) bConverter.Deserialize(saveFilePath);

        saveFilePath.Close();

        return loadData;
    }

    public void SavePerson(Save_PersonInfo p)
    {
        if (Directory.Exists(save_fileName))
        {
            Directory.CreateDirectory(save_fileName);
        }

        BinaryFormatter bConvert = new BinaryFormatter();

        FileStream saveFilePath = File.Create(save_fileName + "/" + "personFile" + ".bin");

        bConvert.Serialize(saveFilePath, p);

        saveFilePath.Close();
    }

    public void AppendSavePerson(Save_PersonInfo p)
    {
        if (!Directory.Exists(save_fileName))
        {
            SavePerson(p);
        }

        BinaryFormatter bConvert = new BinaryFormatter();

        FileStream saveFilePath = File.Create(save_fileName + "/" + "personFile" + ".bin");

        bConvert.Serialize(saveFilePath, p);

        saveFilePath.Close();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // using BinaryReader

    public void BinaryReader_SavePerson(List<Save_PersonInfo> p, bool b_OW)
    {
        if (!Directory.Exists(save_fileName))
        {
            Directory.CreateDirectory(save_fileName);
        }
        
        string content = "";

        foreach (Save_PersonInfo item in p)
        {
            content += (item.getGender().ToString() + " " + item.getAge().ToString()) + '\n';
        }

        if (b_OW)
        {
            using (FileStream stream = new FileStream(path, FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.Write(content);
                }
            }
        
            Debug.Log("success??");
        }
        else
        {
            using (FileStream stream = new FileStream(path, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.Write(content);
                }
            }

            Debug.Log("no success????");
        }        
    }

    public List<Save_PersonInfo> BinaryReader_LoadPerson()
    {
        List<Save_PersonInfo> persons = new List<Save_PersonInfo>();
        Save_PersonInfo person = new Save_PersonInfo();

        List<string> temp = new List<string>();

        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] temp_line = line.Split(' ');

                    int[] temp_info = new int[2];

                    temp_info[0] = int.Parse(temp_line[0]);
                    temp_info[1] = int.Parse(temp_line[1]);

                    person.setInfo(temp_info[0], temp_info[1]);

                    persons.Add(person);
                }

                //string allText = sr.ReadToEnd();
                //persons.AddRange(sr.ReadToEnd().Split(new char[] { '\n' }));
            
            }
        }

        Debug.Log("Caution");

        return persons;
    }

}
