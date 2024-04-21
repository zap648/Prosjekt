using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public struct Person 
{
    public enum GENDER
    {
        FEMALE,
        MALE
    };
    public enum AGE_STATE
    {
        BABY,
        CHILD,
        TEEN,
        YA,
        ADULT,
        OLD
    }
    // oldest possible age
    private int oldestAge;
    private void setOldest()
    {
        oldestAge = 40;
    }
    // current complete age
    public int age_complete;
    // current age
    public int age_current;
    // age status
    public AGE_STATE age_state;
    // gender 0 - f/1 - m
    public GENDER gender;
    private void setGender()
    {
        int i = Random.Range(0, 1);
        
        if (i == 0) 
            { gender = GENDER.FEMALE; }
        else 
            { gender = GENDER.MALE; }
    }
    public GENDER getGender()
    {
        return gender;
    }
    
    // portrait
    private void setPortrait() // set paths!
    {
        if (gender == GENDER.FEMALE)
        {
            if (age_state == AGE_STATE.OLD)
            { 
            
            }
            else if (age_state == AGE_STATE.ADULT)
            { 
            
            }
            else if (age_state == AGE_STATE.YA) 
            { 
            
            }
            else if (age_state == AGE_STATE.TEEN) 
            { 
            
            }
            else if (age_state == AGE_STATE.CHILD)
            {

            }
            else
            {

            }
        }
        else
        {
            if (age_state == AGE_STATE.OLD)
            {

            }
            else if (age_state == AGE_STATE.ADULT)
            {

            }
            else if (age_state == AGE_STATE.YA)
            {

            }
            else if (age_state == AGE_STATE.TEEN)
            {

            }
            else if (age_state == AGE_STATE.CHILD)
            {

            }
            else
            {

            }
        }
    }
    public void getPortrait()
    {
        // what is age status?
        // if female
    }

    // relation to PC
        // spouse, in-law, parent, child, employee, extended family
    public string PC_relation;
    
        // rep to PC (1-5)
    public int PC_rep;

    // status
        // mood (1-5)
        // physical --> ill/healthy/cold/warm/hungry/
        // complete --> alive/dead/left/moved out
}
