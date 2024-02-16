using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    /// describes inventory behaviour

    const float tileHeight = 32;
    const float tileWidth = 32;

    RectTransform rectTransform;

    Vector2 positionOnTheGrid = new Vector2();
    Vector2Int tilePosition = new Vector2Int(); 

    // get the pivot position on Image
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // find the tile the mouse is hovering over
    // mouseposition is sent from ScreenInputCatchInventory.cs (attached to Camera, fires everytime SerializedField is not null)
    public Vector2Int GetTileGridPosition(Vector2 mouseposition)
    {
        positionOnTheGrid.x = mouseposition.x - rectTransform.position.x; 
        positionOnTheGrid.y = rectTransform.position.y - mouseposition.y; 

        tilePosition.x = (int)(positionOnTheGrid.x / tileWidth); 
        tilePosition.y = (int)(positionOnTheGrid.y / tileHeight);

        // Debug.Log(tilePosition);

        return tilePosition; 
    }


}
