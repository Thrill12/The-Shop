using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopitem : UIItemHolder
{
    public bool shouldGetDestroyed = true;
    PlayerMoneys moneys;

    public override void Start()
    {
        base.Start();
        moneys = items.gameObject.GetComponent<PlayerMoneys>();
    }

    public void Buy()
    {
        if(moneys.coins >= itemHeld.itemValue)
        {
            pf.SpawnUIItem(itemHeld);
            pf.GetComponent<AudioSource>().PlayOneShot(pf.audioLib.itemSold);
            moneys.coins -= (int)itemHeld.itemValue;

            if (shouldGetDestroyed)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            pf.GetComponent<AudioSource>().PlayOneShot(pf.audioLib.cantAfford);
        }
    }
}
