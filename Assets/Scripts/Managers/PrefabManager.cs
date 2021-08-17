using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public List<BaseItem> hats;
    public List<BaseItem> chests;
    public List<BaseItem> boots;

    public GameObject itemInventory;

    [Space(5)]

    public GameObject uiItem;

    public PlayerItems items;

    public void SpawnUIItem(BaseItem i)
    {
        GameObject obj = Instantiate(uiItem, itemInventory.transform);
        obj.GetComponent<UIItemHolder>().itemHeld = Instantiate(i);
        items.holders.Add(obj.GetComponent<UIItemHolder>());
    }
}
