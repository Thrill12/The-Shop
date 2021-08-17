using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopitem : UIItemHolder
{
    PrefabManager pf;

    public override void Start()
    {
        base.Start();
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    public void Buy()
    {
        GameObject inst = Instantiate(pf.uiItem, items.inventory.transform);
        inst.GetComponent<UIItemHolder>().itemHeld = itemHeld;
        items.itemsInInventory.Add(itemHeld);
    }
}
