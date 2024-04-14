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
    [SerializeField] public GameObject ActivityBoardPanel;
    [SerializeField] public GameObject HomePanel;
    [SerializeField] public GameObject TraderPanel;
    [SerializeField] public GameObject MarketPanel;
    [SerializeField] public GameObject ChurchPanel;
    [SerializeField] public GameObject MinePanel;

    List<GameObject> List_PlacePanels;

    //// places to go on the map
    [SerializeField] public Button button_home;
    [SerializeField] public Button button_market;
    [SerializeField] public Button button_church;
    [SerializeField] public Button button_trader;
    [SerializeField] public Button button_mine;

    // activities at home
    [SerializeField] Button button_home_visitHome;
    [SerializeField] Button button_home_concludeDay;

    // activities at the market (may be active if market is active)
    [SerializeField] Button button_market_recruitmentInn;
    [SerializeField] Button button_market_pub;
    [SerializeField] Button button_market_park;
    [SerializeField] Button button_market_baker;
    
    // activities at the church (may be active if church is active)
    [SerializeField] Button button_church_ceremony;
    [SerializeField] Button button_church_cemeteray;
    [SerializeField] Button button_church_confession;

    // activities at trader
    [SerializeField] Button button_trader_trade;

    // activities at mine
    [SerializeField] Button button_mine_manageMiners;
    [SerializeField] Button button_mine_goWorkMine;

    // information buttons
    [SerializeField] Button accept_button;
    [SerializeField] Button decline_button;

    /*
    - home
        - conclude day (every time of day)****
        - visit home (eveyr time of day)
    - town
        - pub (evening)*
        - market (morning, day)**
        - recruitment (morning)*
        - baker (morning)
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
        List_PlacePanels = new List<GameObject>();
        AddPanels();
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

    // add panels to management
    private void AddPanels()
    {
        List_PlacePanels.Add(MinePanel);
        List_PlacePanels.Add(ChurchPanel);
        List_PlacePanels.Add(TraderPanel);
        List_PlacePanels.Add(HomePanel);
        List_PlacePanels.Add(MarketPanel);
    }

    // activate and deactivate listeners (handled by the IDognState s
    public void ActivateCorrectActivities(IDognState currentState)
    {
        // only listen to those buttons
        // which should be active in those states
        if(currentState == sm.smMorning)
        {
            // all places active
            button_home.onClick.AddListener(GetHomeActivity);
            button_market.onClick.AddListener(GetMarketActivity);
            button_church.onClick.AddListener(GetChurchActivity);
            button_trader.onClick.AddListener(GetTraderActivity);
            button_mine.onClick.AddListener(GetMineActivity);
            // morning activities active
            button_home_visitHome.onClick.AddListener(Activity_Home_VisitHome);
            button_home_concludeDay.onClick.AddListener(Activity_Home_ConcludeDay);

            button_market_baker.onClick.AddListener(Activity_Market_Baker);
            button_market_recruitmentInn.onClick.AddListener(Activity_Market_Recruitment);

            button_church_cemeteray.onClick.AddListener(Activity_Church_Cemetary);
            button_church_ceremony.onClick.AddListener(Activity_Church_Ceremony);
            button_church_confession.onClick.AddListener(Activity_Church_Confession);

            button_trader_trade.onClick.AddListener(Activity_Trader_Trade);

            button_mine_manageMiners.onClick.AddListener(Activity_Mine_ManageMiners);
            button_mine_goWorkMine.onClick.AddListener(Activity_Mine_WorkMine);
        }
        else if(currentState==sm.smMidday)
        {
            // all places active
            button_home.onClick.AddListener(GetHomeActivity);
            button_market.onClick.AddListener(GetMarketActivity);
            button_church.onClick.AddListener(GetChurchActivity);
            button_trader.onClick.AddListener(GetTraderActivity);
            button_mine.onClick.AddListener(GetMineActivity);
            // midday activities
            button_home_visitHome.onClick.AddListener(Activity_Home_VisitHome);
            button_home_concludeDay.onClick.AddListener(Activity_Home_ConcludeDay);

            button_market_park.onClick.AddListener(Activity_Market_Park);

            button_church_cemeteray.onClick.AddListener(Activity_Church_Cemetary);
            button_church_confession.onClick.AddListener(Activity_Church_Confession);

            button_trader_trade.onClick.AddListener(Activity_Trader_Trade);

            button_mine_manageMiners.onClick.AddListener(Activity_Mine_ManageMiners);
            button_mine_goWorkMine.onClick.AddListener(Activity_Mine_WorkMine);
        }
        else if(currentState == sm.smEvening)
        {
            // all places active
            button_home.onClick.AddListener(GetHomeActivity);
            button_market.onClick.AddListener(GetMarketActivity);
            button_church.onClick.AddListener(GetChurchActivity);
            button_trader.onClick.AddListener(GetTraderActivity);
            button_mine.onClick.AddListener(GetMineActivity);

            // evening activities
            button_home_visitHome.onClick.AddListener(Activity_Home_VisitHome);
            button_home_concludeDay.onClick.AddListener(Activity_Home_ConcludeDay);

            button_market_pub.onClick.AddListener(Activity_Market_Pub);

            button_church_cemeteray.onClick.AddListener(Activity_Church_Cemetary);

            button_trader_trade.onClick.AddListener(Activity_Trader_Trade);

            button_mine_manageMiners.onClick.AddListener(Activity_Mine_ManageMiners);
            button_mine_goWorkMine.onClick.AddListener(Activity_Mine_WorkMine);

        }
        else if(currentState == sm.smNightg)
        {
            // only church and home active
            button_home.onClick.AddListener(GetHomeActivity);
            button_church.onClick.AddListener(GetChurchActivity);

            // evening activities
            button_home_concludeDay.onClick.AddListener(Activity_Home_ConcludeDay);

            button_church_cemeteray.onClick.AddListener(Activity_Church_Cemetary);
        }
        else
        {
            Debug.Log("if-statement couldn't find the current state of  DognStateMachine.cs");
        }
    }
    public void DeactivateCorrectActivities(IDognState currentState)
    {
        if (currentState == sm.smMorning)
        {
            // all places deactivated
            button_home.onClick.RemoveListener(GetHomeActivity);
            button_market.onClick.RemoveListener(GetMarketActivity);
            button_church.onClick.RemoveListener(GetChurchActivity);
            button_trader.onClick.RemoveListener(GetTraderActivity);
            button_mine.onClick.RemoveListener(GetMineActivity);
            // morning activities deactive
            button_home_visitHome.onClick.RemoveListener(Activity_Home_VisitHome);
            button_home_concludeDay.onClick.RemoveListener(Activity_Home_ConcludeDay);

            button_market_baker.onClick.RemoveListener(Activity_Market_Baker);
            button_market_recruitmentInn.onClick.RemoveListener(Activity_Market_Recruitment);

            button_church_cemeteray.onClick.RemoveListener(Activity_Church_Cemetary);
            button_church_ceremony.onClick.RemoveListener(Activity_Church_Ceremony);
            button_church_confession.onClick.RemoveListener(Activity_Church_Confession);

            button_trader_trade.onClick.RemoveListener(Activity_Trader_Trade);

            button_mine_manageMiners.onClick.RemoveListener(Activity_Mine_ManageMiners);
            button_mine_goWorkMine.onClick.RemoveListener(Activity_Mine_WorkMine);

        }
        else if (currentState == sm.smMidday)
        {
            // all places deactivated
            button_home.onClick.RemoveListener(GetHomeActivity);
            button_market.onClick.RemoveListener(GetMarketActivity);
            button_church.onClick.RemoveListener(GetChurchActivity);
            button_trader.onClick.RemoveListener(GetTraderActivity);
            button_mine.onClick.RemoveListener(GetMineActivity);
            // midday activities deactivated
            button_home_visitHome.onClick.RemoveListener(Activity_Home_VisitHome);
            button_home_concludeDay.onClick.RemoveListener(Activity_Home_ConcludeDay);

            button_market_park.onClick.RemoveListener(Activity_Market_Park);

            button_church_cemeteray.onClick.RemoveListener(Activity_Church_Cemetary);
            button_church_confession.onClick.RemoveListener(Activity_Church_Confession);

            button_trader_trade.onClick.RemoveListener(Activity_Trader_Trade);

            button_mine_manageMiners.onClick.RemoveListener(Activity_Mine_ManageMiners);
            button_mine_goWorkMine.onClick.RemoveListener(Activity_Mine_WorkMine);
        }
        else if (currentState == sm.smEvening)
        {
            // all places deactivated
            button_home.onClick.RemoveListener(GetHomeActivity);
            button_market.onClick.RemoveListener(GetMarketActivity);
            button_church.onClick.RemoveListener(GetChurchActivity);
            button_trader.onClick.RemoveListener(GetTraderActivity);
            button_mine.onClick.RemoveListener(GetMineActivity);

            // evening activities
            button_home_visitHome.onClick.RemoveListener(Activity_Home_VisitHome);
            button_home_concludeDay.onClick.RemoveListener(Activity_Home_ConcludeDay);

            button_market_pub.onClick.RemoveListener(Activity_Market_Pub);

            button_church_cemeteray.onClick.RemoveListener(Activity_Church_Cemetary);

            button_trader_trade.onClick.RemoveListener(Activity_Trader_Trade);

            button_mine_manageMiners.onClick.RemoveListener(Activity_Mine_ManageMiners);
            button_mine_goWorkMine.onClick.RemoveListener(Activity_Mine_WorkMine);
        }
        else if (currentState == sm.smNightg)
        {
            // all places deactivated
            button_home.onClick.RemoveListener(GetHomeActivity);
            button_church.onClick.RemoveListener(GetChurchActivity);

            // evening activities
            button_home_concludeDay.onClick.RemoveListener(Activity_Home_ConcludeDay);

            button_church_cemeteray.onClick.RemoveListener(Activity_Church_Cemetary);
        }
        else
        {
            Debug.Log("(deactivate) if-statement couldn't find the current state of  DognStateMachine.cs");
        }
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
    
    // when clicking one of the Activity Buttons, the appropriate activity Meny should be activated
    // de/activate board
    // de/activate check and exit button
    // trigger animation/picture to play when appropriate
    // counter (when two has been added - we need to change state (send message to statemachine)

    public void Activity_Home_ConcludeDay() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);
        }



    }
    public void Activity_Home_VisitHome() { }
    public void Activity_Market_Recruitment() { }
    public void Activity_Market_Baker() { }
    public void Activity_Market_Park() { }
    public void Activity_Market_Pub() { }
    public void Activity_Church_Cemetary() { }
    public void Activity_Church_Confession() { }
    public void Activity_Church_Ceremony() { }
    public void Activity_Trader_Trade() { }
    public void Activity_Mine_WorkMine() { }
    public void Activity_Mine_ManageMiners() { }
}
