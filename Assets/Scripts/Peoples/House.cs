using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
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
}
