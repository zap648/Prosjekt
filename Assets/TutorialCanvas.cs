using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<ByUI>())
        {
            Debug.Log("ByUI was found!");
            Debug.Log($"It is day {FindObjectOfType<ByUI>().days}!");
            if (FindObjectOfType<ByUI>().days == 1)
            {
                Debug.Log($"Tutorial canvas is true!");
                gameObject.SetActive(true);
            }
            else
            {
                Debug.Log($"Tutorial canvas is false!");
                gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Can not find ByUI!");
        }
    }
}
