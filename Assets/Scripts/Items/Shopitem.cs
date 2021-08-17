using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopitem : UIItemHolder
{
    PrefabManager pf;
    PlayerMoneys moneys;

    public override void Start()
    {
        base.Start();
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
        moneys = items.gameObject.GetComponent<PlayerMoneys>();
    }

    public void Buy()
    {
        if(moneys.coins > itemHeld.itemValue)
        {
            pf.SpawnUIItem(itemHeld);
            moneys.coins -= (int)itemHeld.itemValue;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Can't afford");
        }
    }
}
