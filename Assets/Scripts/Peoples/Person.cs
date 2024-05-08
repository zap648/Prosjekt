using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
enum GENDER
    {
        FEMALE, MALE
    };
    public enum AGE_STATE
    {
        BABY, CHILD, TEEN, Y_ADULT, ADULT, OLD
    };
    enum MOOD
    {
        ECSTATIC, VERY_HAPPY, HAPPY, FINE, UNHAPPY, VERY_UNHAPPY, MISERABLE
    };
    enum RELATIONSHIP_W_PC_IS
    {
        SPOUSE, PARENT, INLAW, CHILD, EMPLOYEE, FRIEND
    };
    enum HAPPINESS_W_RELATIONSHIP_IS
    {
        ECSTATIC, VERY_HAPPY, HAPPY, FINE, UNHAPPY, VERY_UNHAPPY, MISERABLE
    };
    enum STATE // only alive state should be listed in in-house family list
    {
        ALIVE,      
        MOVED_OUT,  // if child, "successfully raised" them buff, else ignore 
        DEAD,       // if any positive relationship, "mourn" them else ignore
        ESTRANGED   // "sadness" buff
    };

    public struct debuff
    {

    }
    public struct buff
    {

    }

    /*  
        status
        // mood (1-5)
        // physical --> ill/healthy/cold/warm/hungry/fine/fed
        // complete --> alive/dead/left/moved out
    */


[System.Serializable]
public struct Person
{

    [SerializeField] public GameObject portrait_prefab;
    private string portrait;

    [SerializeField] public AldringStateMachine sm;
    
    int age;
    
    public AGE_STATE age_state;
    
    GENDER gender;

    // figure out which buff should be applied
    private void getBuff()
    {

    }
    // figure out which debuff should be applied
    private void getDebuff()
    {

    }
    // figure out what the person should want
    private void getWant()
    {

    }
    
    private void Start()
    {
        // set relationship with PC (get from load)
    }

    // roll for age
    private void RollAge()
    {
        this.age = Random.Range(0, 71);
    }
    // set age
    private void setAge(int a)
    {
        this.age = a;
    }
    // get age
    private int getAge()
    {
        return age;
    }

    // roll for AGE_STATE
    private void RollAGE_STATE()
    {
        //age_state = (AGE_STATE) sm.age;
        age_state = (AGE_STATE)Random.Range(0, 6);
    }
    // set AGE_STATE
    private void setAGE_STATE(int a)
    {
        this.age = a;

        if (age < 3)
        {
            this.age_state = AGE_STATE.BABY;
        }
        else if (age < 9 && age > 2)
        {
            this.age_state = AGE_STATE.CHILD;
        }
        else if (age < 15 && age > 8)
        {
            this.age_state = AGE_STATE.TEEN;
        }
        else if (age < 17 && age > 14)
        {
            this.age_state = AGE_STATE.Y_ADULT;
        }
        else if (age < 65 && age > 16)
        {
            this.age_state = AGE_STATE.ADULT;
        }
        else
        {
            this.age_state = AGE_STATE.OLD;
        }
    }
    // get AGE_STATE
    private AGE_STATE getAGE_STATE()
    {
        return age_state;
    }

    // roll for GENDER
    private void RollGENDER()
    {
        int i = Random.Range(0, 2);

        if (i == 0)
        { gender = GENDER.FEMALE; }
        else
        { gender = GENDER.MALE; }
    }
    // set GENDER
    private void setGENDER(int g)
    {
        gender = (GENDER)g;
    }
    // get GENDER 
    private GENDER getGENDER()
    {
        return gender;
    }

    // set portrait string
    private void setPortrait() 
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
            else if (age_state == AGE_STATE.Y_ADULT)
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
            else if (age_state == AGE_STATE.Y_ADULT)
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
    // get correct portrait from Resource folder
    public Sprite getPortrait()
    {
        Sprite p = Resources.Load<Sprite>(portrait);

        return p;
    }

    private void applyPortrait()
    {
        if (portrait_prefab != null)
        {
            Sprite image = portrait_prefab.GetComponentInChildren<Image>().sprite;

            image = getPortrait();
        }
    }

    /////////////////////////////////////////////////////////////////

    /// <summary>
    /// sets all Person values to build a Family member (portrait)
    /// </summary>
    /// <param name="a">Person's age. 0-70</param> 
    /// <param name="g">Person's gender. 0 - female, 1 - male, turned to enum</param> 
    /// <returns>fully built person</returns>
    public Person setAllPersonValues(int a, int g)
    {
        setAge(a);
        setGENDER(g);
        setPortrait();
        getPortrait();
        applyPortrait();

        return this;
    }

    private void RollAllPersonValues()
    {
        RollAge();
        setAGE_STATE(age);
        RollGENDER();
        setPortrait();
    }

    public Person getAllPersonValues()
    {
        RollAllPersonValues();
        return this;
    }
}
