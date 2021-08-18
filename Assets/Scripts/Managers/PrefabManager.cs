using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public List<BaseItem> heads;
    public List<BaseItem> chests;
    public List<BaseItem> boots;
    public List<BaseItem> hats;

    public GameObject itemInventory;
    public GameObject shopItem;

    public GameObject shop;

    [Space(5)]

    public GameObject uiItem;

    public PlayerItems items;

    public void SpawnUIItem(BaseItem i)
    {
        GameObject obj = Instantiate(uiItem, itemInventory.transform);
        obj.GetComponent<UIItemHolder>().itemHeld = Instantiate(i);
        obj.GetComponent<UIItemHolder>().itemHeld.isEquipped = false;
        obj.GetComponent<UIItemHolder>().shouldRandomize = false;
        items.holders.Add(obj.GetComponent<UIItemHolder>());
        items.itemsInInventory.Add(obj.GetComponent<UIItemHolder>().itemHeld);
    }

    public void SpawnShopItem()
    {
        GameObject obj = Instantiate(shopItem, shop.transform);
        obj.GetComponent<Shopitem>().shouldRandomize = true;
    }
}
