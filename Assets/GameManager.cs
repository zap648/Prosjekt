// using System.Collections;
using System.Collections.Generic;
// using System.Security.Cryptography;
// using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int bank;
    public List<int> coalInventory;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("There's no GameManager!");
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

    private static void SetUpInstance()
    {
        _instance = FindObjectOfType<GameManager>();

        if (_instance == null)
        {
            GameObject gm = new GameObject();
            gm.name = "GameManager";
            _instance = gm.AddComponent<GameManager>();
            DontDestroyOnLoad(gm);
            Debug.Log("Game Manager initialized!");
        }
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
