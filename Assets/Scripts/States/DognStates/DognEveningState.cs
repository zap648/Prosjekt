using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognEveningState : IDognState
{
    public override void Enter(DognStateMachine sm)
    {
        // get evening menu 
        // enable evening activities
        sm.byUI.button_home.onClick.AddListener(sm.byUI.GetHomeActivity);
        sm.byUI.button_market.onClick.AddListener(sm.byUI.GetMarketActivity);
        sm.byUI.button_church.onClick.AddListener(sm.byUI.GetChurchActivity);
        sm.byUI.button_trader.onClick.AddListener(sm.byUI.GetTraderActivity);
        sm.byUI.button_mine.onClick.AddListener(sm.byUI.GetMineActivity);
        // set timer for mine to 3hrs
    }
    public override void Update(DognStateMachine sm)
    {
        // condition counter

        // if condition is met, Exit this state
    }
    public override void Exit(DognStateMachine sm)
    {
        // set timer to 0hrs
        // disable evening activities
        sm.byUI.button_home.onClick.RemoveListener(sm.byUI.GetHomeActivity);
        sm.byUI.button_market.onClick.RemoveListener(sm.byUI.GetMarketActivity);
        sm.byUI.button_church.onClick.RemoveListener(sm.byUI.GetChurchActivity);
        sm.byUI.button_trader.onClick.RemoveListener(sm.byUI.GetTraderActivity);
        sm.byUI.button_mine.onClick.RemoveListener(sm.byUI.GetMineActivity);

        // close down evening menu
    }
}
