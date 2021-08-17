using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemHolder : MonoBehaviour
{
    public BaseItem itemHeld;

    private TMP_Text itemName;
    private TMP_Text itemValue;
    private Image itemIcon;

    [HideInInspector]
    public PlayerItems items;
    private Image backgorundImage;

    public virtual void Start()
    {
        itemName = transform.Find("ItemName").GetComponent<TMP_Text>();
        itemValue = transform.Find("CoinsIcon").transform.Find("ItemValue").GetComponent<TMP_Text>();
        itemIcon = transform.Find("ItemIcon").GetComponent<Image>();

        items = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
        backgorundImage = GetComponent<Image>();

        itemName.text = itemHeld.itemName;
        itemValue.text = itemHeld.itemValue.ToString();
        itemIcon.sprite = itemHeld.itemIcon;

        itemHeld.isEquipped = false;
    }

    private void Update()
    {
        if (itemHeld.isEquipped)
        {
            backgorundImage.color = Color.green;
        }
        else
        {
            backgorundImage.color = Color.white;
        }
    }

    public void ToggleEquip()
    {
        if (itemHeld.isEquipped)
        {
            Unequip();
        }
        else
        {
            Equip();
        }
    }

    public void Equip()
    {
        items.UnequipInSlot(itemHeld.itemSlot);
        items.EquipItem(itemHeld);
    }

    public void Unequip()
    {
        items.UnequipItem(itemHeld);
    }
}
