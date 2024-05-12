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
    [SerializeField] SaveLoad_Singleton save;
    public bool iBy;
    public bool iGruve;
    public int day;
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
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (FindObjectOfType<ByUI>() && iGruve)
        {
            Debug.Log("Fann ByUI! >:D");
            iGruve = false; iBy = true;
            FindObjectOfType<ByUI>().sm.SwitchState(FindObjectOfType<ByUI>().sm.smNight);
            // FindObjectOfType<SaveLoad_Singleton>().Stream_LoadCalender();
        }

        if (FindObjectOfType<GruveGenerator>() && iBy)
        {
            Debug.Log("Fann GruveGenerator! D:>");
            iGruve = true; iBy = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
