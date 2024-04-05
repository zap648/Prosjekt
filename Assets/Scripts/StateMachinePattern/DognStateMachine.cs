using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DognStateMachine : MonoBehaviour
{
    IDognState currentState;
    public DognMorningState smMorning = new DognMorningState(); 
    public DognMiddayState smMidday = new DognMiddayState(); 
    public DognEveningState smEvening = new DognEveningState(); 
    public DognNightState smNightg = new DognNightState(); 

    private void Start()
    {
        // when starting game, it is always morning
        // set current to be morning state
        currentState = smMorning;
        // enter current state
        currentState.Enter(this);
    }

    private void Update()
    {
        // update current state with current state
        currentState.Update(this);
    }

    public void SwitchState(IDognState state)
    {
        // new currenet state
        currentState = state;
        // enter current state
        currentState.Enter(this);
    }
}
