[System.Serializable]
public class ItemsSlots 
{
    public ItemsBase Items;
    public string ItemName;
    public int Stack;

    public ItemsSlots(ItemsBase newItem, int newStack)
    {
        Items = newItem;
        Stack = newStack;
    }
}
