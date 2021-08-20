using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Clothing itemEquipped;

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

    public void EquipItem(Clothing i)
    {
        itemEquipped = i;
        i.isEquipped = true;
        rend.sprite = i.equippedSprite;
    }

    public void UnequipItem(Clothing i)
    {
        i.isEquipped = false;
        itemEquipped = null;       
        rend.sprite = null;
    }
}
