// using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum HOUSE_TYPE
{
    TYPE1, TYPE2, TYPE3, TYPE4, TYPE5
};

public struct house
{
    private HOUSE_TYPE TYPE;

    int rent;
    int warming;
    int repair;
    int decay;
    int wetness;

    public void setExpense(HOUSE_TYPE type)
    {
        this.TYPE = type;

        switch(type)
        {
            case HOUSE_TYPE.TYPE1:
                rent = 10;
                warming = 100;
                repair = 100;
                decay = 50;
                wetness = 100;
                break; 
            case HOUSE_TYPE.TYPE2:
                rent = 30;
                warming = 70;
                repair = 90;
                decay = 40;
                wetness = 90;
                break; 
            case HOUSE_TYPE.TYPE3:
                rent = 60;
                warming = 80;
                repair = 70;
                decay = 60;
                wetness = 60;
                break; 
            case HOUSE_TYPE.TYPE4:
                rent = 100;
                warming = 90;
                repair = 40;
                decay = 70;
                wetness = 30;
                break; 
            case HOUSE_TYPE.TYPE5:
                rent = 150;
                warming = 100;
                repair = 0;
                decay = 90;
                wetness = 0;
                break;
        }
    }

    public void setTYPE(HOUSE_TYPE t)
    {
        TYPE = t;
    }
    public HOUSE_TYPE getTYPE() { return TYPE; }
}

/// <summary>
/// used by SaveLoad_Singleton to save current house to 
/// </summary>
public struct saveload_house
{
    public int _houseType;

    public void prepareHouse(HOUSE_TYPE type)
    {
        _houseType = (int)type;
    }

    public void setHouse(HOUSE_TYPE type)
    {
        _houseType =(int)type;
    }

    public int getHouseType() {  return _houseType; }

}

public class House : MonoBehaviour
{
    /*
    int m_wetness;
    int m_repair;
    int m_warmth;

    int m_house_level = 1;

    int[] wetness_day;
    int[] repair_day;
    int[] warmth_day;

    int yr = 28;

    int[] arr_house;

    private void Awake()
    {
        int wetDay = 3;
        int repDay = 11;
        int warDay = 4;

        wetness_day = new int[yr];
        repair_day = new int[yr];
        warmth_day = new int[yr];

        int b_add = -1; // prep for wetness
        for (int i = 0; i < yr; i++)
        {
            wetness_day[i] = wetDay + (1 * b_add);

            if (wetDay == 0) // if we have reached 0, it is time to add
                b_add = 1;

            if (wetDay == 14) // if we have reached 14, do not add
                b_add = -1;
        }
        
        b_add = 1; // prep for repair
        for (int i = 0; i < yr; i++)
        {
            repair_day[i] = repDay + (1 * b_add);

            if (repDay == 0) // if we have reached 0, it is time to add
                b_add = 1;

            if (repDay == 14) // if we have reached 14, do not add
                b_add = -1;
        }

        b_add = 1; // prep for warmth
        for (int i = 0; i < yr; i++)
        {
            warmth_day[i] = warDay + (1 * b_add);

            if (warDay == 0) // if we have reached 0, it is time to add
                b_add = 1;

            if (warDay == 14) // if we have reached 14, do not add
                b_add = -1;
        }
        
        arr_house = new int[4];
    }

    private void setWetness(int day)
    {
        m_wetness = wetness_day[day];
    }
    private void setRepair(int day)
    {
        m_repair = repair_day[day];
    }
    private void setWarmth(int day)
    {
        m_warmth = warmth_day[day];
    }

    private void setHouseLevel(bool paid)
    {
        if (paid)
        {
            m_house_level++;
        }
    }

    public void setHouseState(int day)
    {
        // home menu will ask the house to fix itself
        setWetness(day); setRepair(day); setWarmth(day);
    }
    public int[] getHouseState()
    {

        arr_house[0] = m_house_level;
        arr_house[1] = m_repair;
        arr_house[2] = m_warmth;
        arr_house[3] = m_wetness;

        return arr_house;
    }
    */

    SaveLoad_Singleton _askInstance;
    HOUSE_TYPE _type;
    [SerializeField] public house house;

    private void Start()
    {
        _askInstance = GetComponent<SaveLoad_Singleton>();

        if (_askInstance == null)
        {
            _askInstance = SaveLoad_Singleton.Instance;
        }
        
        DefineHouse();
    }

    private void DefineHouse()
    {
        saveload_house buildHouseInfo = new saveload_house();

        if (_askInstance.AskForDirectory("TestingPathName/houseFile.bin"))
        {
            Debug.Log("House component, directory not found");
            buildHouseInfo = _askInstance.Stream_LoadHouse();
            insertLInfo(buildHouseInfo);
        }
        else
        {
            Debug.Log("House component, defines default house");
            // build default house
            BuildDefaultHouse();
        }
    }

    private void BuildDefaultHouse()
    {
        house = new house();
        house.setExpense((HOUSE_TYPE)0);
        // immediatly save house?
        SaveCurrentHouse();
    }

    public void LoadCurrentHouse()
    {
        saveload_house current = new saveload_house();
        
        //_askInstance.
    }
    public void SaveCurrentHouse()
    {
        saveload_house savedHouse = new saveload_house();

        savedHouse = insertSInfo();

        _askInstance.Stream_SaveHouse(savedHouse);

    }

    public saveload_house insertSInfo()
    {
        saveload_house temp = new saveload_house();

        temp._houseType = (int) house.getTYPE();

        return temp;
    }

    private void insertLInfo(saveload_house loadedHouse)
    {
        house.setTYPE((HOUSE_TYPE)loadedHouse.getHouseType());
    }
}
