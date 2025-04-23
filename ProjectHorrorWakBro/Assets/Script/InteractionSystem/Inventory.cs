using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Picked up: " + item.itemName);
    }

    public bool HasKey(int keyId)
    {
        return items.Exists(i => i.keyId == keyId);
    }
}
