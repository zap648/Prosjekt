using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int bank;
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

    public void LoadScene(int sceneId)
    {
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
}
