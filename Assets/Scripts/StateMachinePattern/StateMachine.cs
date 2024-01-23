using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    public menuSystemState msystemState = new menuSystemState();
    public menuCharCreateState mcharcreateState = new menuCharCreateState();
    public gamePrepGroupState mprepgroupState = new gamePrepGroupState();
    public gamePrepShopState mprepshopState = new gamePrepShopState();
    public gameHomeStartState mhomestartState = new gameHomeStartState();
    public gameHomeEndState mhomeendState = new gameHomeEndState();
    public gameCityRecruitState mcityrecruitState = new gameCityRecruitState();
    public gameMineState mmineState = new gameMineState();

    private void Start()
    {
        currentState = msystemState;
        currentState.Enter(this);
    }
    private void Update()
    {
        currentState.Update(this);
    }
    public void SwitchState(IState state)
    {
        currentState = state;
        currentState.Enter(this);
    }
}

