using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item; // Reference to the item

    public void Pickup(Inventory playerInventory)
    {
        playerInventory.AddItem(item);
        Destroy(gameObject);
    }
}
