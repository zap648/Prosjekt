using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

// class to allow invoking of button prompts

public class ByUI : MonoBehaviour
{
    // ref to DayCycle and allowed places and activities
    public DognStateMachine sm;
    public int AllowedPlaces;
    public int AllowedActivities;

    // places to go on the map
    [SerializeField] Button button_home;
    [SerializeField] Button button_market;
    [SerializeField] Button button_church;
    [SerializeField] Button button_trader;
    [SerializeField] Button button_rafinery;
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

    // Events attached to buttons -> places
    public UnityEvent goHome;
    public UnityEvent goMarket;
    public UnityEvent goChurch;
    public UnityEvent goTrader;
    public UnityEvent goRafinery;
    public UnityEvent goMine;
    // Events attached to buttons -> activities
    public UnityEvent doRecruitmentInn;
    public UnityEvent doPub;
    public UnityEvent doPark;
    public UnityEvent doBaker;
    public UnityEvent doCeremony;
    public UnityEvent doCemetary;
    public UnityEvent doConfession;


    
}
