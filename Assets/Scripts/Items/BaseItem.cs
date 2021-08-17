using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BaseItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public float itemValue;
    public Slot itemSlot;

    [HideInInspector]
    public bool isEquipped = false;

    public enum Slot
    {
        Head,
        Chest,
        Boots
    }
}
