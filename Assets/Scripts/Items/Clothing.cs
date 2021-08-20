using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu, System.Serializable]
public class Clothing : BaseItem
{
    public Sprite equippedSprite;
    public Slot itemSlot;

    public enum Slot
    {
        Head,
        Hat,
        Chest,
        Boots
    }
}
