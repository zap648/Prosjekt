using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> coalInventory;

    // Start is called before the first frame update
    void Start()
    {
        // When the scene loads, calculate the value of the gained coal
        //for (int i = 0; i < coalInventory.Count; i++)
        //{
        //    caveFund += coalInventory[i].GetComponent<CoalInfo>().value;
        //}
        //coalInventory.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
=======

    public void LoadScene(int sceneId)
    {
        FillBank();

        SceneManager.LoadScene(sceneId);
    }

    void FillBank()
    {
        for (int i = 0; i < coalInventory.Count; i++)
        {
            bank += coalInventory[i];
        }
        coalInventory.Clear();
    }
>>>>>>> Stashed changes
}
