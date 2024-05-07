using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InsertCoal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        CoalElevator coalElevator = GetComponent<CoalElevator>();
        List<GameObject> playerInventory = interactor.GetComponent<Player>().inventory;

        if (coalElevator == null)
        {
            Debug.Log("Failed to find coal elevator!");
            return false;
        }

        if (coalElevator.cargo.Count >= coalElevator.limit)
        {
            Debug.Log("Elevator is full");
            return false;
        }

        if (playerInventory.Count <= 0)
        {
            Debug.Log("Has no coal to insert");
            return false;
        }

        coalElevator.cargo.Add(playerInventory.First());
        playerInventory.First().SetActive(true);
        playerInventory.First().transform.position = transform.position;
        playerInventory.First().GetComponent<CoalInfo>().mined = true;
        playerInventory.Remove(playerInventory.First());

        Debug.Log("Inserted coal!");
        return true;
    }
}
