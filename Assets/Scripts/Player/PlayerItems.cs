using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public ItemSlot head;
    public ItemSlot chest;
    public ItemSlot boots;
    public ItemSlot hat;

    [Space(5)]

    public List<BaseItem> itemsInInventory;
    public List<Clothing> itemsEquipped;
    public List<UIItemHolder> holders;

    [Space(5)]

    public GameObject inventory;

    private void Start()
    {
        holders = new List<UIItemHolder>();
    }

    public void EquipItem(Clothing i)
    {
        if(i.itemSlot == Clothing.Slot.Head)
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
        else if (i.itemSlot == Clothing.Slot.Hat)
        {
            if (hat.itemEquipped != null)
            {
                UnequipInSlot(i.itemSlot);
                hat.EquipItem(i);
            }
            else
            {
                hat.EquipItem(i);
            }
        }
        else if (i.itemSlot == Clothing.Slot.Chest)
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
        else if(i.itemSlot == Clothing.Slot.Boots)
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

    public void UnequipItem(Clothing i)
    {
        if (i.itemSlot == Clothing.Slot.Head)
        {
            if (head.itemEquipped != null)
            {
                head.UnequipItem(i);
            }
        }
        else if (i.itemSlot == Clothing.Slot.Hat)
        {
            if (hat.itemEquipped != null)
            {
                hat.UnequipItem(i);
            }
        }
        else if (i.itemSlot == Clothing.Slot.Chest)
        {
            if (chest.itemEquipped != null)
            {
                chest.UnequipItem(i);
            }
        }
        else if (i.itemSlot == Clothing.Slot.Boots)
        {
            if (boots.itemEquipped != null)
            {
                boots.UnequipItem(i);
            }
        }       
    }

    public void UnequipInSlot(Clothing.Slot slot)
    {
        foreach (UIItemHolder holder in holders)
        {
            if(holder.itemHeld is Clothing)
            {
                Clothing holderClothing = (Clothing)holder.itemHeld;
                if (holderClothing.itemSlot == slot && holder.itemHeld.isEquipped == true)
                {
                    holder.Unequip();
                }
            }
                      
        }
    }
}
