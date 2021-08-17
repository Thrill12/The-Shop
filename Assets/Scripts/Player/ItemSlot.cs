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
    }

    public void EquipItem(BaseItem i)
    {
        itemEquipped = i;

        rend.sprite = i.itemIcon;
    }

    public void UnequipItem()
    {
        itemEquipped = null;

        rend.sprite = null;
    }
}
