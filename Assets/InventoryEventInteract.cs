using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryEventInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    ScreenInputCatchInventory mouseOnScreenCatch;
    InventoryInteraction inventoryinteraction;
    
    private void Awake()
    {
        mouseOnScreenCatch = FindObjectOfType<ScreenInputCatchInventory>();
        inventoryinteraction = GetComponent<InventoryInteraction>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mouse exit inventory!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouse exit inventory!");
    }


}
