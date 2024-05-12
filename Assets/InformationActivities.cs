using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationActivities : MonoBehaviour
{
    public string ParseActivityType(ACTIVITY mType)
    {
        string mInfo;
    
        switch (mType)
        {
            case ACTIVITY.VISIT_HOME:
                mInfo = "You visited the family. A treat to see them during the day.";
                break;
            case ACTIVITY.END_DAY:
                mInfo = "You decide to end the day. Chosing this option will end the day and move time one day forward.";
                break;
            case ACTIVITY.PUB:
                mInfo = "The pub is allways lively. A good place to meet people, talk, and laugh."; 
                break;
            case ACTIVITY.HIRE:
                mInfo = "You go to hire miners for your expedition."; 
                break;
            case ACTIVITY.MARKET:
                mInfo = "Some days only fresh food will do."; 
                break;
            case ACTIVITY.CEMETARY:
                mInfo = "You went to the cemetary. A good place to remember those that have passed away."; 
                break;
            case ACTIVITY.CEREMONY:
                mInfo = "Morning ceremony to feed the soul."; 
                break;
            case ACTIVITY.CONFESSION:
                mInfo = "Some days it is good to ease the burdens by sharing them with the pastor."; 
                break;
            case ACTIVITY.TRADE:
                mInfo = "You go to the trader to exchange what you've got."; 
                break;
            case ACTIVITY.WORK:
                mInfo = "Time to work! Chosing this action will send you to the mine."; 
                break;
            case ACTIVITY.MANAGE:
                mInfo = "When there are groups of people there will be a need to manage them."; 
                break;
            default:
                mInfo = "default."; 
                break;
        }
        return mInfo;
    }

}
