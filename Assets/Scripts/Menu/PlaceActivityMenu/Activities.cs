using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// script for the activities which player can chose
/// between in the menu system
/// </summary>
public class Activities : MonoBehaviour
{
    public int RollFor(int chance)
    {
        int returnValue;

        switch (chance)
        {
            // 50% chance
            case 1:
                returnValue = RandomNumberGenerator(2);
                // failed or succeeded
            break;
            // 33% chance
            case 2:
                returnValue = RandomNumberGenerator(3);
                // failed, nothing happened, succeeded
            break;
            // 25% chance
            case 3:
                returnValue = RandomNumberGenerator(4);
                // bad, nothing happened, good, surprise
            break;
            // 20% chance
            case 4:
                int temp = 2;
                temp = RandomNumberGenerator(temp);
                
                bool b_degree = false;
                if (temp == 1)
                    b_degree = false;
                else if (temp == 2)
                    b_degree = true;

                returnValue = RandomNumberGenerator(temp);

                // return value of negative is
                // a bad result while positive is a good result
                if (!b_degree)
                    returnValue *= (-1);

                // degree of bad/good
                // extremely bad, very bad, bad, irritant, failure
                // extremely good, very good, good, good, success
            break;
            // 16% chance
            case 5:
                returnValue = RandomNumberGenerator(6);
            break;
            // 14% chance
            case 6:
                returnValue = RandomNumberGenerator(7);
            break;

            default:
                returnValue = RandomNumberGenerator(7);
            break;
        }

        return returnValue;
    }

    private int RandomNumberGenerator(int max) 
    {
        return Random.Range(1, max);
    }
}
