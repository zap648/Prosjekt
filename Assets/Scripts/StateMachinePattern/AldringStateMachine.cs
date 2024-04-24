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
    
    [SerializeField] public Person person;    
    
    private void Start()
    {
        // get state from person struct
        person = GetComponent<Person>();

        int state = (int)person.age_state;

        switch (state)
        {
            case 0:
                currentState = smBaby;
                break;
            case 1: 
                currentState = smChild;
                break;
            case 2: 
                currentState = smTeen;
                break;
            case 3: 
                currentState = smYAdult;
                break;
            case 4: 
                currentState = smAdult;
                break;
            case 5: 
                currentState = smOld;
                break;
            default:
                currentState = smBaby;
                break;
        }

        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    public void SwitchState(IAldringState state)
    {
        currentState = state;
        currentState.Enter(this);
    }
}
