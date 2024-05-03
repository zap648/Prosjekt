using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseElevator : MonoBehaviour , IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Elevator elevator = GetComponent<Elevator>();

        if (elevator == null)
        {
            Debug.Log("Failed to find elevator!");
            return false;
        }

        if (GetComponent<GruveElevator>() != null) { GetComponent<GruveElevator>().cargo.Add(interactor.gameObject); }

        if (elevator.atBottom) { elevator.Hoist(); }
        else if (elevator.atTop) { elevator.Lower(); }

        Debug.Log("Using elevator!");
        return true;
    }
}
