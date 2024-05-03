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

        coalElevator.cargo.Add(interactor.GetComponent<Player>().inventory.Last());
        interactor.GetComponent<Player>().inventory.Last().SetActive(true);
        interactor.GetComponent<Player>().inventory.Last().transform.position = transform.position;
        interactor.GetComponent<Player>().inventory.Last().GetComponent<CoalInfo>().mined = true;

        Debug.Log("Inserted coal!");
        return true;
    }
}
