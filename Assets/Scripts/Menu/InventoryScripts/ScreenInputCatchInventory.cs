using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInputCatchInventory : MonoBehaviour
{
    [SerializeField] InventoryInteraction mouseInput;

    private void Update()
    {
        if (mouseInput == null)
        {
            return;
        }

        Debug.Log(mouseInput.GetTileGridPosition(Input.mousePosition));
    }
}
