using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public ItemSlot head;
    public ItemSlot chest;
    public ItemSlot boots;

    [Space(5)]

    public List<BaseItem> itemsInInventory;
    public List<BaseItem> itemsEquipped;
    public List<UIItemHolder> holders;

    [Space(5)]

    public GameObject inventory;

    private void Start()
    {
        holders = new List<UIItemHolder>();
    }

    public void EquipItem(BaseItem i)
    {
        if(i.itemSlot == BaseItem.Slot.Head)
        {
            if(head.itemEquipped != null)
            {
                UnequipInSlot(i.itemSlot);
                head.EquipItem(i);
            }
            else
            {
                head.EquipItem(i);
            }
        }
        else if (i.itemSlot == BaseItem.Slot.Chest)
        {
            if (chest.itemEquipped != null)
            {
                UnequipInSlot(i.itemSlot);
                chest.EquipItem(i);
            }
            else
            {
                chest.EquipItem(i);
            }
        }
        else if(i.itemSlot == BaseItem.Slot.Boots)
        {
            if (boots.itemEquipped != null)
            {
                UnequipInSlot(i.itemSlot);
                boots.EquipItem(i);
            }
            else
            {
                boots.EquipItem(i);
            }
        }
    }

    public void UnequipItem(BaseItem i)
    {
        if (i.itemSlot == BaseItem.Slot.Head)
        {
            if (head.itemEquipped != null)
            {
                head.UnequipItem(i);
            }
        }
        else if (i.itemSlot == BaseItem.Slot.Chest)
        {
            if (chest.itemEquipped != null)
            {
                chest.UnequipItem(i);
            }
        }
        else if (i.itemSlot == BaseItem.Slot.Boots)
        {
            if (boots.itemEquipped != null)
            {
                boots.UnequipItem(i);
            }
        }       
    }

    public void UnequipInSlot(BaseItem.Slot slot)
    {
        foreach (UIItemHolder holder in holders)
        {
            if (holder.itemHeld.itemSlot == slot && holder.itemHeld.isEquipped == true)
            {
                holder.Unequip();
            }
        }
    }
}
