using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldringStateMachine : MonoBehaviour
{
    public IAldringState currentState;
    public AldringBabyState smBaby = new AldringBabyState();
    public AldringChildState smChild = new AldringChildState();
    public AldringTeenState smTeen = new AldringTeenState();
    public AldringYAdultState smYAdult = new AldringYAdultState();
    public AldringAdultState smAdult = new AldringAdultState();
    public AldringOldState smOld = new AldringOldState();

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SwitchState(IAldringState state)
    {

    }
}
