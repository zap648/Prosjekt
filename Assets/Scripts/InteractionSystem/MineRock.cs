using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRock : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (gameObject.GetComponent<CoalInfo>() == null)
        {
            Debug.Log("Failed to find rock!");
            return false;
        }

        if (gameObject.GetComponent<CoalInfo>().mined)
        {
            Debug.Log("Rock is not minable");
            return false;
        }

        gameObject.SetActive(false);

        Debug.Log("Mining rock!");
        return true;
    }
}
