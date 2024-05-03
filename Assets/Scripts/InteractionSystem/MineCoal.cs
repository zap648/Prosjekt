using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCoal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (gameObject.GetComponent<CoalInfo>() == null)
        {
            Debug.Log("Failed to find coal!");
            return false;
        }

        if (gameObject.GetComponent<CoalInfo>().mined)
        {
            Debug.Log("Coal is not minable");
            return false;
        }

        interactor.GetComponent<Player>().inventory.Add(gameObject);
        gameObject.SetActive(false);

        Debug.Log("Mining coal!");
        return true;
    }
}
