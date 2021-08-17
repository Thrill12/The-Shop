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
        itemValue = transform.Find("ItemValue").GetComponent<TMP_Text>();
        itemIcon = transform.Find("ItemIcon").GetComponent<Image>();

        items = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
        backgorundImage = GetComponent<Image>();

        itemName.text = itemHeld.itemName;
        itemValue.text = itemHeld.itemValue.ToString();
        itemIcon.sprite = itemHeld.itemIcon;
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
        backgorundImage.color = Color.green;
    }

    public void Unequip()
    {
        backgorundImage.color = Color.white;
        items.UnequipItem(itemHeld);
    }
}
