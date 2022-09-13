using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "InventoryItemData", menuName = "Inventory/Create new item")]
public class InventoryItem : ScriptableObject
{
    public string name;
    public Sprite image;
}
