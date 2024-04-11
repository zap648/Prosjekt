using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
// using UnityEngine.UIElements;
using UnityEngine.UI;

// class to allow invoking of button prompts

public class ByUI : MonoBehaviour
{
    // ref to DayCycle and allowed places and activities
    public DognStateMachine sm;
    public int AllowedPlaces;
    public int AllowedActivities;

    // timer to make buttons unable to accept clicks
    private float _time = 0.1f;
    bool b_startTimer;

    [SerializeField] public GameObject ActivityPanel;
    [SerializeField] public GameObject HomePanel;
    [SerializeField] public GameObject TraderPanel;
    [SerializeField] public GameObject MarketPanel;
    [SerializeField] public GameObject ChurchPanel;
    [SerializeField] public GameObject MinePanel;

    List<GameObject> List_PlacePanels;

    //// places to go on the map
    [SerializeField] Button button_home;
    [SerializeField] Button button_market;
    [SerializeField] Button button_church;
    [SerializeField] Button button_trader;
    [SerializeField] Button button_mine;

    // activities at the market (may be active if market is active)
    [SerializeField] Button button_market_recruitmentInn;
    [SerializeField] Button button_market_pub;
    [SerializeField] Button button_market_park;
    [SerializeField] Button button_market_baker;
    
    // activities at the church (may be active if church is active)
    [SerializeField] Button button_church_ceremony;
    [SerializeField] Button button_church_cemeteray;
    [SerializeField] Button button_church_confession;

    /*
    - home
        - conclude day (every time of day)****
    - town
        - pub (evening)*
        - market (morning, day)**
        - recruitment (morning)*
    - church
        - ceremony (morning)*
        - confession (morning, day, evening)***
        - cemetary (every time of day)****
    - trader
        - store (morning, day, evening)***
    - mine 8
        - work in mine (morning, day, evening)***
        - manage mining team (morning, day, evening)***
     */

    private void Start()
    {
        button_home.onClick.AddListener(GetHomeActivity);
        button_market.onClick.AddListener(GetMarketActivity);
        button_church.onClick.AddListener(GetChurchActivity);
        button_trader.onClick.AddListener(GetTraderActivity);
        button_mine.onClick.AddListener(GetMineActivity);

        List_PlacePanels = new List<GameObject>();
        AddPanels();
    }

    private void AddPanels()
    {
        List_PlacePanels.Add(MinePanel);
        List_PlacePanels.Add(ChurchPanel);
        List_PlacePanels.Add(TraderPanel);
        List_PlacePanels.Add(HomePanel);
        List_PlacePanels.Add(MarketPanel);
    }

    // when clicking one of the Place Buttons, the Activity Menu should be activated
    public void GetHomeActivity()
    {
        if (!HomePanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }

            HomePanel.SetActive(true);
            b_startTimer = true;
        }
        else if (HomePanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }
            // MinePanel.SetActive(false);
        }
    }
    public void GetMarketActivity()
    {
        if (!MarketPanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }

            MarketPanel.SetActive(true);
            b_startTimer = true;
        }
        else if (MarketPanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }
            // MinePanel.SetActive(false);
        }
    }
    public void GetChurchActivity()
    {
        if (!ChurchPanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }

            ChurchPanel.SetActive(true);
            b_startTimer = true;
        }
        else if (ChurchPanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }
            // MinePanel.SetActive(false);
        }
    }
    public void GetTraderActivity()
    {
        if (!TraderPanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }

            TraderPanel.SetActive(true);
            b_startTimer = true;
        }
        else if (TraderPanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }
            // MinePanel.SetActive(false);
        }
    }
    public void GetMineActivity()
    {
        if (!MinePanel.activeSelf && !b_startTimer)
        { 
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }

            MinePanel.SetActive(true);
            b_startTimer = true;
        }
        else if (MinePanel.activeSelf && !b_startTimer) 
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }
            // MinePanel.SetActive(false);
        }
    }

    private void Update()
    {
        if(b_startTimer)
        {
            _time += 0.1f;

            if(_time >= 0.5f)
            {
                b_startTimer = false;
                _time = 0.1f;
            }
        }
    }
}
