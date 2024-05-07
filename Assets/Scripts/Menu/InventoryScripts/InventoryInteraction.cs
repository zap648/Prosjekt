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

    // size of inventory
    InventoryItem[,] inventoryitemSlot;
    [SerializeField] int inventorySizeWidth = 20;
    [SerializeField] int inventorySizeHight = 10;

    [SerializeField] GameObject defaultItemPrefab;

    // get the pivot position on Image
    private void Start()
    {
        // used to find position in inventory
        rectTransform = GetComponent<RectTransform>();
        
        // initialize size of inventory
        Init(inventorySizeWidth, inventorySizeHight);

        InventoryItem inventoryItemDefault = Instantiate(defaultItemPrefab).GetComponent<InventoryItem>();
        PlaceItem(inventoryItemDefault, 0, 1);
    }

    private void Init(int inventoryWidth, int inventoryHeight)
    {
        // TODO: is it possible to move the inventory to 'onscreen' if part of it is 
        // outside of the screen? Or maybe able to move the inventory by clicking and
        // dragging?
        // should the inventory be 'on' a background which can move the entire inventory
        // if generated outside of the screen?
        inventoryitemSlot = new InventoryItem[inventoryWidth, inventoryHeight];

        Vector2 size = new Vector2(inventoryWidth * tileWidth, inventoryHeight * tileHeight);
        rectTransform.sizeDelta = size;
    }


    // find the tile the mouse is hovering over
    // mouseposition is sent from ScreenInputCatchInventory.cs (attached to Camera, fires everytime SerializedField is not null)
    public Vector2Int GetTileGridPosition(Vector2 mouseposition)
    {
        positionOnTheGrid.x = mouseposition.x - rectTransform.position.x; 
        positionOnTheGrid.y = rectTransform.position.y - mouseposition.y; 

        tilePosition.x = (int)(positionOnTheGrid.x / tileWidth); 
        tilePosition.y = (int)(positionOnTheGrid.y / tileHeight);

        return tilePosition; 
    }

    public void PlaceItem(InventoryItem item, int posX, int posY)
    {
        RectTransform itemRectTransform = item.GetComponent<RectTransform>();
        itemRectTransform.SetParent(this.rectTransform);

        inventoryitemSlot[posX, posY] = item;

        Vector2 position = new Vector2();
        position.x = posX * tileWidth + tileWidth / 2;
        position.y = -posY * tileHeight + tileHeight / 2;

        itemRectTransform.localPosition = position;
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        InventoryItem toReturn = inventoryitemSlot[x, y];
        inventoryitemSlot[x, y] = null; 
        
        return toReturn;
    }
}
