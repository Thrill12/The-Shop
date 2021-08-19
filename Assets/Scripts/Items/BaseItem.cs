using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu, System.Serializable]
public class BaseItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public Sprite equippedSprite;
    public float itemValue;
    public bool isEquippable = true;
    public Slot itemSlot;
    public GameObject plant;
    public bool isEquipped = false;

    public enum Slot
    {
        Head,
        Hat,
        Chest,
        Boots
    }
}
