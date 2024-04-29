using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calender : MonoBehaviour
{
    [SerializeField] GameObject DayCounterPanel;
    TMP_Text daycounter;

    TestForSaveingStruct testing;
    SaveLoad_Singleton instance_ask;
    
    // count of calendar
    int day_count;
    int week_count;
    int month_count;
    // total amount of days/weeks/months
    int day_complete;
    int week_complete;
    int month_complete;

    private void Start()
    {
        instance_ask = GetComponent<SaveLoad_Singleton>();

        if (instance_ask != null )
        {
            instance_ask = SaveLoad_Singleton.Instance;
        }
        
        day_count = 0;
        week_count = 0;
        month_count = 0;

        day_complete = 0;
        week_complete = 0;
        month_complete = 0;

        if (DayCounterPanel != null)
        {    
            daycounter = DayCounterPanel.GetComponentInChildren<TMP_Text>();
        }

        UpdateDayCounter();
    }

    public void UpdateDayCounter()
    {
        // first sort out what's the day and so on
        CalendarUpdate();

        if (DayCounterPanel != null)
        {
            // current calander day (1-7)
            daycounter.SetText(day_count.ToString());
        }
    }

    /// <summary>
    /// asks singleton for day/week/month- complete
    /// then counts forward
    /// returns 
    /// </summary>
    private void CalendarUpdate()
    {
        int[] calander = new int[3];
        // ask singleton for an update
        // testing = instance_ask.ReadFromFile("Day");
        
        // singleton has no info- do not add day
        // if singleton has info, add another day to current and count
        
        day_complete++;
        day_count++;

        if (day_count < 7)
        {
            week_complete++;
            week_count++;

            day_count = 0;

            if(week_count < 7)
            {
                month_complete++;
                month_count++;

                week_count = 0;
            }
        }

        calander[0] = day_count;
        calander[1] = week_count;
        calander[3] = month_count;

    }
}
