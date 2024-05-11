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
    public saveload_house HouseInfo;
    public saveload_calender CalenderInfo;

    string path = "TestingPathName/personFile.bin";
    string housepath = "TestingPathName/houseFile.bin";
    string calenderpath = "TestingPathName/calenderFile.bin";

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

    public bool AskForDirectory(string paths)
    {
        if (!Directory.Exists(paths)) { return false; }
        else { return true; }
    }

    // using BinaryReader

    // person
    public void Stream_SavePerson(List<Save_PersonInfo> p, bool b_OW)
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
        }        
    }

    public List<Save_PersonInfo> Stream_LoadPerson()
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
            }
        }
        return persons;
    }

    // house
    public void Stream_SaveHouse(saveload_house h)
    {
        if (!Directory.Exists(save_fileName))
        {
            Directory.CreateDirectory(save_fileName);
        }

        string content = "";

        content = h.getHouseType().ToString() + " ";
        

        using (FileStream stream = new FileStream(housepath, FileMode.Truncate))
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write(content);
            }
        }
    }

    public saveload_house Stream_LoadHouse()
    {
        saveload_house house = new saveload_house();

        List<string> temp = new List<string>();

        using (FileStream stream = new FileStream(housepath, FileMode.Open))
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

                    house.setHouse((HOUSE_TYPE)temp_info[0]);

                }
            }
        }
        return house;
    }

    // calender
    public void Stream_SaveCalender(saveload_calender c)
    {
        if (!Directory.Exists(save_fileName))
        {
            Directory.CreateDirectory(save_fileName);
        }

        string content = "";

        content = c.getDayNR().ToString() + " " + c.getMonthNR().ToString() + " " + c.getYearNR().ToString();


        using (FileStream stream = new FileStream(housepath, FileMode.Truncate))
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write(content);
            }
        }
    }

    public saveload_calender Stream_LoadCalender()
    {
        saveload_calender calendersender = new saveload_calender();

        List<string> temp = new List<string>();

        using (FileStream stream = new FileStream(housepath, FileMode.Open))
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
                    temp_info[2] = int.Parse(temp_line[2]);


                    calendersender.setCalenderDetails(temp_info);
                }
            }
        }
        return calendersender;
    }

}
