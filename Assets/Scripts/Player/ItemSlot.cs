using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public BaseItem itemEquipped;

    public bool shouldFlip;

    private SpriteRenderer rend;
    private Sprite startSprite;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startSprite = rend.sprite;

        if(itemEquipped != null)
        {
            rend.sprite = itemEquipped.itemIcon;
            itemEquipped = Instantiate(itemEquipped);
            itemEquipped.isEquipped = false;
        }
    }

    private void Update()
    {
        if(itemEquipped == null)
        {
            rend.sprite = startSprite;
        }

        if (shouldFlip)
        {
            if (itemEquipped != null)
            {
                rend.flipX = true;
            }
            else
            {
                rend.flipX = false;
            }
        }
        
    }

    public void EquipItem(BaseItem i)
    {
        itemEquipped = i;
        i.isEquipped = true;
        rend.sprite = i.equippedSprite;
    }

    public void UnequipItem(BaseItem i)
    {
        i.isEquipped = false;
        itemEquipped = null;       
        rend.sprite = null;
    }
}
