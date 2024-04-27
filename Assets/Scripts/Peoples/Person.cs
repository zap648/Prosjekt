using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
    enum GENDER
    {
        FEMALE, MALE
    };
    enum AGE_STATE
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
public class Person : MonoBehaviour
{

    [SerializeField] public GameObject portrait_prefab;
    private string portrait;

    [SerializeField] public AldringStateMachine sm;
    int age;
    AGE_STATE age_state;
    int max_age = 54;

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

    // set AGE_STATE
    private void setAGESTATE()
    {
        age_state = (AGE_STATE) sm.age;
        // age_state = (AGE_STATE)Random.Range(0, 6);
    }
    // get AGE_STATE
    private AGE_STATE getAGE_STATE()
    {
        return age_state;
    }

    // set GENDER 
    private void setGENDER()
    {
        int i = Random.Range(0, 2);

        if (i == 0)
        { gender = GENDER.FEMALE; }
        else
        { gender = GENDER.MALE; }
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

    /////////////////////////////////////////////////////////////////
    
    private void setAllPersonValues()
    {
        setGENDER();
        setAGESTATE();
        setPortrait();
    }

    public Person getAllPersonValues()
    {
        setAllPersonValues();
        return this;
    }
}
