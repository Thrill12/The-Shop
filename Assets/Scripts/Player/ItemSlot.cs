using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public BaseItem itemEquipped;

    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        if(itemEquipped != null)
        {
            rend.sprite = itemEquipped.itemIcon;
            itemEquipped = Instantiate(itemEquipped);
            itemEquipped.isEquipped = false;
        }
    }

    public void EquipItem(BaseItem i)
    {
        itemEquipped = i;
        i.isEquipped = true;
        rend.sprite = i.itemIcon;
    }

    public void UnequipItem(BaseItem i)
    {
        i.isEquipped = false;
        itemEquipped = null;       
        rend.sprite = null;
    }
}
