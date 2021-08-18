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

    public bool shouldRandomize = false;
    [HideInInspector]
    public PlayerItems items;
    private Image backgorundImage;
    [HideInInspector]
    public PrefabManager pf;
    private Planter planter;

    public virtual void Start()
    {
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();

        if (shouldRandomize)
        {
            int rand = Random.Range(0, 4);

            if (rand == 0)
            {
                itemHeld = Instantiate(pf.heads[Random.Range(0, pf.heads.Count)]);
            }
            else if (rand == 1)
            {
                itemHeld = Instantiate(pf.chests[Random.Range(0, pf.chests.Count)]);
            }
            else if (rand == 2)
            {
                itemHeld = Instantiate(pf.boots[Random.Range(0, pf.boots.Count)]);
            }
            else
            {
                itemHeld = Instantiate(pf.hats[Random.Range(0, pf.hats.Count)]);
            }
        }       

        itemName = transform.Find("ItemName").GetComponent<TMP_Text>();
        itemValue = transform.Find("CoinsIcon").transform.Find("ItemValue").GetComponent<TMP_Text>();
        itemIcon = transform.Find("ItemIcon").GetComponent<Image>();

        items = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
        backgorundImage = GetComponent<Image>();
        planter = items.gameObject.GetComponent<Planter>();
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
        if (itemHeld.isEquippable)
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
        else
        {
            planter.currentlySelected = itemHeld.plant;
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

    public void Sell()
    {
        items.gameObject.GetComponent<PlayerMoneys>().coins += (int)itemHeld.itemValue;
        Destroy(gameObject);
    }
}
