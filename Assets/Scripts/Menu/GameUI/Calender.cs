using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calender : MonoBehaviour
{
    [SerializeField] GameObject DayCounterPanel;
    
    TMP_Text daycounter;
    
    int day_current;
    int day_count;
    int week_current;
    int week_count;
    int month_current;
    int month_count;
    int year_current;
    int year_count;

    private void Start()
    {
        Debug.Log("Days in Calender :" + day_current);

        day_current = 5;

        Debug.Log("Days should be 5, set in Calender :" + day_current);

        if (DayCounterPanel != null)
        {
            Debug.Log("Finds daycounter panel:" + day_current);
            
            daycounter = DayCounterPanel.GetComponentInChildren<TMP_Text>();
        }

        UpdateDayCounter();
    }

    // calculates how many % chance it is of disaster to strike
    // day 0 - 6%,
    // 12%, 18%, 24%, 30%, 36%, 42%, day 7 - 48%,
    // 54%, 60%, 66%, 72%, 78%, 84%, day 14 - 90%
    // lowest day is 0, highest is 14, 
    // when reaching highest, counts backwards,
    // when reaching lowest, counts higher
    public int ChanceOfDisaster(int d)
    {

        return 0;
    }

    public void UpdateDayCounter()
    {
        if (DayCounterPanel != null)
        {
            daycounter.SetText(day_current.ToString());

        }
    }
}
