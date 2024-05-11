using TMPro;
using UnityEngine;

public struct saveload_calender
{
    public int day_nr;

    public int sl_weekday;
    public int sl_month;
    public int sl_year;

    public void setDayNR(int d) { day_nr = d; }
    public void insertDayNR(int d) { day_nr = d; }
    public int getDayNR() { return sl_weekday; }
    public int getMonthNR() { return sl_month; }
    public int getYearNR() { return sl_year; }

    public void setCalenderDetails(int[] cal)
    {
        sl_weekday = cal[0];
        sl_month = cal[1];
        sl_year = cal[2];
    }
    
    public int[] detCalenderDetails()
    {
        int[] cal = new int[3];

        cal[0] = sl_weekday;
        cal[1] = sl_month;
        cal[2] = sl_year;

        return cal;
    }
}

public class Calender : MonoBehaviour
{
    [SerializeField] GameObject DayCounterPanel;
    TMP_Text daycounter;

    SaveLoad_Singleton instance_ask;
    
    // count of calendar
    int m_day_nr;

    // temp
    int weekday;
    int month;
    int year;

    private void Start()
    {
        bool b_find = FindObjectOfType<GameObject>().gameObject.Equals(name == "SaveLoadSingleton");

        instance_ask = GameObject.Find("SaveLoadSingleton").GetComponent<SaveLoad_Singleton>();

        if (instance_ask != null )
        {
            instance_ask = SaveLoad_Singleton.Instance;
        }

        Debug.Log("start method in calender.cs");

        m_day_nr = 1;
        weekday = 1;
        month = 1;
        year = 1;

        SaveDayNr();

        /*day_count = 0;
        week_count = 0;
        month_count = 0;

        day_complete = 0;
        week_complete = 0;
        month_complete = 0;

        if (DayCounterPanel != null)
        {    
            daycounter = DayCounterPanel.GetComponentInChildren<TMP_Text>();
        }

        UpdateDayCounter();*/
    }

    /// <summary>
    /// sorts the calender details. Makes an array with weekday, month, and year.
    /// </summary>
    /// <returns>a saveload_calender struct with the details of current calender, and saves it</returns>
    private saveload_calender whichDayWeekMonth()
    {
        saveload_calender calender = new saveload_calender();
        int[] details = new int[3];
        
        // find year
        if (m_day_nr > 28)  
        {
            year = m_day_nr % 28;
        }
        else
        {
            year = 1;
        }
        details[2] = year;
        
        // find month
        if (m_day_nr < 8)
        {
            month = 1;
        }
        else
        {
            month = support(1, m_day_nr, true);
        }
        details[1] = month;

        // find day
        if (m_day_nr < 8)
        {
            weekday = m_day_nr;
        }
        else
        {
            weekday = support(1, m_day_nr, false);
        }
        details[0] = weekday;

        calender.setCalenderDetails(details);

        instance_ask.Stream_SaveCalender(calender);

        return calender;
    }

    /// <summary>
    /// a supporting method, sorts through values to find calender details
    /// </summary>
    /// <param name="counter">how many times can divide with, or how many in-game months</param>
    /// <param name="num">the remains, or which weekday is it</param>
    /// <param name="b_count">what will be returned</param>
    /// <returns>returns either which weekday or which month it is, depending on b_count</returns>
    private int support(int counter, int num, bool b_count)
    {
        if (num <= 7)
        {
            if (b_count)
            {
                return counter;
            }
            else
            { 
                return num; 
            }
        }

        support(counter++, num -7, b_count);

        if (b_count)
        {
            return counter;
        }
        else
        {
            return num;
        }
    }

    /// <summary>
    /// get the correct nr day to be displayed on screen
    /// </summary>
    public void setCounter()
    {
        instance_ask = GameObject.Find("SaveLoadSingleton").GetComponent<SaveLoad_Singleton>();

        if (instance_ask != null)
        {
            instance_ask = SaveLoad_Singleton.Instance;
        }

        updateCounter();

        daycounter = DayCounterPanel.GetComponent<TMP_Text>();

        // sets visibile counter
        saveload_calender c = new saveload_calender();

        c = LoadDay();
        Debug.Log("It is day nr: " + c.day_nr);

        Debug.Log("day: " + c.getDayNR() + " | month: " + c.getMonthNR() + " | year: " + c.getYearNR());

        daycounter.SetText(c.getDayNR().ToString());
    }
    /// <summary>
    /// other components uses this to update the daycounter.
    /// the day is incremented, saved to file, and then displayed
    /// </summary>
    public void updateCounter()
    {
        if(m_day_nr < 1)
        {
            m_day_nr = 1;
        }
        else
        {
            m_day_nr++;
        }

        SaveDayNr();

        //setCounter();
    }

    /// <summary>
    /// used by component to save day information
    /// </summary>
    private void SaveDayNr()
    {
        saveload_calender c = new saveload_calender();
        int[] cal = new int[3];

        cal[0] = m_day_nr;
        cal[1] = month;
        cal[2] = year;

        Debug.Log("day: " + cal[0] + " | month: " + cal[1] + " | year: " + cal[2]);
        
        c.setCalenderDetails(cal);

        if (instance_ask != null)
        {
            instance_ask.Stream_SaveCalender(c);
        }
    }
    /// <summary>
    /// used by component to load day information
    /// </summary>
    /// <returns>saveload_calander struct</returns>
    private saveload_calender LoadDay()
    {
        saveload_calender c = new saveload_calender();

        if (instance_ask != null)
        {
            c = instance_ask.Stream_LoadCalender();
        }

        return c;
    }


    /*
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
        calander[2] = month_count;

    }
    */
}
