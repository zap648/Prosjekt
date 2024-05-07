using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryEventInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // all the possible menues can be added here to control if it is
    // possible to interact with them or not

    ScreenInputCatchInventory mouseOnScreenCatch;
    InventoryInteraction inventoryinteraction;
    
    private void Awake()
    {
        mouseOnScreenCatch = FindObjectOfType<ScreenInputCatchInventory>();
        inventoryinteraction = GetComponent<InventoryInteraction>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOnScreenCatch.selectedItemGrid = inventoryinteraction;
        Debug.Log("mouse enter inventory!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOnScreenCatch.selectedItemGrid = null;
        Debug.Log("mouse exit inventory!");
    }


}
