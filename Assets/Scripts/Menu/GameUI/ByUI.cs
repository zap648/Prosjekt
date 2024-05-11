using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// class to allow invoking of button prompts
enum ACTIVITY
{
    NONE, END_DAY, VISIT_HOME, PUB, HIRE, MARKET, TRADE, CEMETARY, CEREMONY, CONFESSION, WORK, MANAGE
};

public class ByUI : MonoBehaviour
{
    // ref to DayCycle and allowed places and activities
    public DognStateMachine sm;
    Activities menuActivity;

    public int chanceNr;

    [SerializeField] public int days = 0;
    
    // timer to make buttons unable to accept clicks
    private float _time = 0.1f;
    bool b_startTimer;

    [SerializeField] public GameObject ActivityPanel;
    [SerializeField] public GameObject ActivityBoardPanel;
    [SerializeField] public GameObject ActivityIllustrationPanel;
    [SerializeField] public GameObject AcceptDeclineActivityPanel;
    [SerializeField] public GameObject InformationPanel;
    [SerializeField] public GameObject HomePanel;
    [SerializeField] public GameObject TraderPanel;
    [SerializeField] public GameObject MarketPanel;
    [SerializeField] public GameObject ChurchPanel;
    [SerializeField] public GameObject MinePanel;
    [SerializeField] GameObject DayCounterPanel;
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

    // reusable information for panels
    // INFORMATION
    Image InformationPic;
    Sprite informationPictureSprite;
    // ILLUSTRATION - sprite
    Sprite illustrationSprite;
    Image IllustrationActivity;

    // info about amount of activities and if they are accepted or not
    [SerializeField] private int _declineAccept = 0;
    private ACTIVITY mACTIVITY = ACTIVITY.NONE;

    private void Start()
    {
        menuActivity = GetComponent<Activities>();
        List_PlacePanels = new List<GameObject>();
        AddPanels();
        Debug.Log("Days in ByUI :" + days);
    }
    private void Update()
    {
        if(b_startTimer)
        {
            _time += 0.1f;

            if(_time >= 0.3f)
            {
                b_startTimer = false;
                _time = 0.1f;

                if (ActivityIllustrationPanel.activeSelf)
                {
                    ActivityIllustrationPanel.SetActive(false);
                }
                if (ActivityBoardPanel.activeSelf)
                {
                    RemoveActivityBoard();
                }
            }
        }

        if (_declineAccept != 0)
        {
            resultDeclineAccept();
        }
    }

    // method to activate when an activity is chosen AND it is delined/accepted
    void resultDeclineAccept()
    {
        if (_declineAccept == 1)
        {
            _declineAccept = 0;
        }
        // correct panels has to be activated with the 'current' information/images/similar
        // when this is done, _declineAccept must be set back to 0;
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
        else if(currentState == sm.smNight)
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
        else if (currentState == sm.smNight)
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
    public void UpdateDayCounter()
    {
        if (DayCounterPanel != null)
        {
            TMP_Text daycounter = DayCounterPanel.GetComponentInChildren<TMP_Text>();

            daycounter.SetText(days.ToString()); 

        }

    }
  
    // when clicking one of the Activity Buttons, the appropriate activity Meny should be activated
    // de/activate board
    // de/activate check and exit button
    // trigger animation/picture to play when appropriate
    // counter (when two has been added - we need to change state (send message to statemachine)

    private void AcceptButton()
    {
        // add to counter
        sm._activityCounter++; // should inform state machine control.cs
        // remove listeners
        RemoveAcceptDeclineListeners();
        _declineAccept = 2;
        //DeclineAccept_Button?.Invoke();
        TestFoo();

        // if accepted, and this activity require a Random Roll, then the result should be displayed,
        // and accounted for as a consequence during the day
    }
    private void DeclineButton()
    {
        // remove listeners
        RemoveAcceptDeclineListeners();
        // remove board
        ActivityBoardPanel.SetActive(false);

        _declineAccept = 1;
        //DeclineAccept_Button?.Invoke();
    }
    private void RemoveAcceptDeclineListeners()
    {
        // remove listeners
        accept_button.onClick.RemoveListener(AcceptButton);
        decline_button.onClick.RemoveListener(DeclineButton);
    }
    private void TestFoo()
    {
        if (_declineAccept == 1) // declines activity
        {
            RemoveActivityBoard();
            mACTIVITY = ACTIVITY.NONE;
            _declineAccept = 0;
        }
        else if (_declineAccept == 2) // accepts activity
        {
            AcceptDeclineActivityPanel.SetActive(false);

            if (mACTIVITY == ACTIVITY.END_DAY)
            {
                sm.SwitchState(sm.smMorning);
            }

            Debug.Log("Illustration is now playing!");
            InformationPanel.SetActive(false);
            ActivityIllustrationPanel.GetComponent<Image>().sprite = illustrationSprite;
            ActivityIllustrationPanel.SetActive(true);

            _time = -30f;
            b_startTimer = true;

            // remember to set mACTIVITY back to NONE when done with it!
            mACTIVITY = ACTIVITY.NONE;
        }
    }
    private void RemoveActivityBoard()
    {
        if (ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(false);

            if (!InformationPanel.activeSelf)
            {
                InformationPanel.SetActive(true);
            }
        }
    }


    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    ///    


    /// <summary>
    /// PLACES
    /// </summary>

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
            RemoveActivityBoard();
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
            GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(1);
        }
        else if (MinePanel.activeSelf && !b_startTimer)
        {
            foreach (GameObject panel in List_PlacePanels)
            {
                panel.SetActive(false);
            }
        }
    }


    /// <summary>
    /// ACTIVITIES
    /// </summary>


    public void Activity_Home_ConcludeDay() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }     

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");
        
        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");
        
        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // mark type of activity with enum
        mACTIVITY = ACTIVITY.END_DAY;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }
    }    
    public void Activity_Home_VisitHome() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");

        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }
        int returnForRoll = menuActivity.RollFor(1);

        Debug.Log("Visisted home and rolled: " + returnForRoll);
    }
    public void Activity_Market_Recruitment() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");

        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }
    }
    public void Activity_Market_Baker() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");

        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }

        int returnForRoll = menuActivity.RollFor(2);
        Debug.Log("Went to the baker and rolled: " + returnForRoll);
    }
    public void Activity_Market_Pub() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");
       
        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");
        
        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }

        int returnForRoll = menuActivity.RollFor(4);

        Debug.Log("Drank at the pub and rolled: " + returnForRoll);
    }
    public void Activity_Church_Cemetary() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");

        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }

        int returnForRoll = menuActivity.RollFor(3);

        Debug.Log("Meditated at the cemetery and rolled: " + returnForRoll);
    }
    public void Activity_Church_Confession() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");

        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }

        int returnForRoll = menuActivity.RollFor(2);
        Debug.Log("Confessed to the preacher and rolled: " + returnForRoll);
    }
    public void Activity_Church_Ceremony() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");

        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }

        int returnForRoll = menuActivity.RollFor(4);
        Debug.Log("Attended the morning service and rolled: " + returnForRoll);
    }
    public void Activity_Trader_Trade() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");
      
        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");

        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }
    }
    public void Activity_Mine_WorkMine() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }

        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");
        
        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");
      
        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }
    }
    public void Activity_Mine_ManageMiners() 
    {
        if (!ActivityBoardPanel.activeSelf)
        {
            ActivityBoardPanel.SetActive(true);

            // add listeners
            accept_button.onClick.AddListener(AcceptButton);
            decline_button.onClick.AddListener(DeclineButton);
        }
        
        // add correct information meta 
        informationPictureSprite = Resources.Load<Sprite>("TestAssetsFolder/pngtree-important-notice-megaphone-sticker-sign-png-image_6480153");
        
        // add correct illustration image
        illustrationSprite = Resources.Load<Sprite>("TestAssetsFolder/having-fun");
        
        // setting information to panel
        InformationPic = InformationPanel.GetComponent<Image>();
        InformationPic.sprite = informationPictureSprite;

        // make sure the yes/no panel is present!
        if (!AcceptDeclineActivityPanel.activeSelf)
        {
            AcceptDeclineActivityPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Decline/accept panel was already on");
        }
    }
}
