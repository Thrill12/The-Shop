using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopitem : UIItemHolder
{
    PlayerMoneys moneys;

    public override void Start()
    {
        base.Start();
        moneys = items.gameObject.GetComponent<PlayerMoneys>();
    }

    public void Buy()
    {
        if(moneys.coins > itemHeld.itemValue)
        {
            pf.SpawnUIItem(itemHeld);
            moneys.coins -= (int)itemHeld.itemValue;
            pf.SpawnShopItem();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Can't afford");
        }
    }
}
