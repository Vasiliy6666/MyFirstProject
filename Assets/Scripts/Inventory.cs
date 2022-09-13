using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] inventoryItems;
    public InventorySlot[] inventorySlots;

    public static Inventory Instance;

    private void Start()
    {
        Instance = this;
    }

    public void AddItem(InventoryItem inventoryItem)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.inventoryItem == null)
            {
                slot.inventoryItem = inventoryItem;
                slot.img.sprite = inventoryItem.image;
                break;
            }
        }
    }

    public void DeleteItem(InventoryItem inventoryItem)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.inventoryItem == inventoryItem)
            {
                slot.inventoryItem = inventoryItem;
                slot.img.sprite = slot.defaultSprite;
                break;
            }
        }
    }

    [ContextMenu("AddRandomItem")]
    public void AddRandomItem()
    {
        // 0 1 2 3 4 5
        AddItem(inventoryItems[Random.Range(0, inventoryItems.Length)]);
    }
    
    [ContextMenu("DeleteRandomItem")]
    public void DeleteRandomItem()
    {
        // 0 1 2 3 4 5
        DeleteItem(inventoryItems[Random.Range(0, inventoryItems.Length)]);
    }
}
