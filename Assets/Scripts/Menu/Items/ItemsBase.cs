using UnityEngine;

public abstract class ItemsBase
{
    // name
    public abstract string ItemName();
    // is item stackable?
    public abstract bool B_stackable();
    // items stack in 5s as a standard
    public virtual int ItemStack()
    {
        // this one should first check if item is stackable
        if (B_stackable())
        {
            return 5;
        }
        else
        {
            return 1;
        }
    }
    // item should have a default image attached

    // type (equipable, light, etc.)
    public abstract int ItemType();
    // can be used up
    // when is it used up, check if used up
    // durability
    // what is current durability, check status
    // value
    // sellable
    // only usable by some?

}
