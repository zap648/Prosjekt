using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInputCatchInventory : MonoBehaviour
{
    public InventoryInteraction mouseInput;


    private void Update()
    {
        if (mouseInput == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(mouseInput.GetTileGridPosition(Input.mousePosition));
        }
    }
}
