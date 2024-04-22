using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public struct Person 
{
    /// <summary>
    /// enums
    /// </summary>

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

    public AldringStateMachine sm { get; }

    /// <summary>
    /// variables
    /// </summary>
    
    // character portrait
    string portrait;
    // gender 0 - f/1 - m
    public GENDER gender;
    // age status
    public AGE_STATE age_state;
    // oldest possible age
    public int oldestAge;
    // current complete age
    public int age_complete;
    // current age
    public int age_current;
    
    /// <summary>
    /// sets and gets
    /// </summary>
    
    // set oldest possible age
    private void setOldest()
    {
        oldestAge = 40;
    }
    // get oldest possible age
    private int getOldest()
    {
        return oldestAge;
    }

    // set gender enum
    private void setGender()
    {
        int i = Random.Range(0, 1);
        
        if (i == 0) 
            { gender = GENDER.FEMALE; }
        else 
            { gender = GENDER.MALE; }
    }
    // get gender enum
    private GENDER getGender()
    {
        return gender;
    }
    
    // set AGE_STATE
    private void setAGESTATE()
    {
        age_state = (Person.AGE_STATE)sm.age;
    }
    // get AGE_STATE

    // set portrait
    private void setPortrait() // set paths!
    {
        if (gender == GENDER.FEMALE)
        {
            if (age_state == AGE_STATE.OLD)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_f_old_v0";
            }
            else if (age_state == AGE_STATE.ADULT)
            { 
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_f_adult_v0";
            }
            else if (age_state == AGE_STATE.YA) 
            { 
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_f_y-adult_v0";
            }
            else if (age_state == AGE_STATE.TEEN) 
            { 
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_f_teen_v0";
            }
            else if (age_state == AGE_STATE.CHILD)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_f_child_v0";
            }
            else
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_baby_v0";
            }
        }
        else
        {
            if (age_state == AGE_STATE.OLD)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_m_old_v0";
            }
            else if (age_state == AGE_STATE.ADULT)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_m_adult_v0";
            }
            else if (age_state == AGE_STATE.YA)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_m_y-adult_v0";
            }
            else if (age_state == AGE_STATE.TEEN)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_m_teen_v0";
            }
            else if (age_state == AGE_STATE.CHILD)
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_m_child_v0";
            }
            else
            {
                portrait = "HomeMenuAssets/Portraits/portrait_familymember_baby_v0";
            }
        }
    }
    private Sprite getPortrait()
    {
        Sprite p = Resources.Load<Sprite>(portrait);
        
        return p;
    }

    /////////////////////////////////////////////////////////////////
    // relation to PC
    // spouse, in-law, parent, child, employee, extended family
    private string PC_relation;

    // rep to PC (1-5)
    private int PC_rep;

    // status
        // mood (1-5)
        // physical --> ill/healthy/cold/warm/hungry/
        // complete --> alive/dead/left/moved out

    public void setAllPersonValues()
    {
        setOldest();
        setAGESTATE();
        setGender();
        setPortrait();
    }

    public Person getAllPersonValues()
    {
        return this;
    }

}
