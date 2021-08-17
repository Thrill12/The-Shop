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
        rend.sprite = itemEquipped.itemIcon;
    }

    public void EquipItem(BaseItem i)
    {
        itemEquipped = i;
        i.isEquipped = true;
        rend.sprite = i.itemIcon;
    }

    public void UnequipItem(BaseItem i)
    {
        itemEquipped = null;
        i.isEquipped = false;
        rend.sprite = null;
    }
}
