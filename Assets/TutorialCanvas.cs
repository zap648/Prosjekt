using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<ByUI>())
        {
            Debug.Log("ByUI was fucking found!");
            if (FindObjectOfType<ByUI>().days == 0)
            {
                Debug.Log("Tutorial canvas is fucking true!");
                gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Tutorial canvas is fucking false!");
                gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Cannot fucking find ByUI!");
        }
    }
}
