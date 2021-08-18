using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject shopDisplay;
    public GameObject inventory;

    public bool shouldSellItems = true;

    private PrefabManager pf;

    private void Start()
    {
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            shopDisplay.SetActive(true);

            for (int i = 0; i < 20; i++)
            {
                pf.SpawnShopItem(this);
            }

            inventory.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            foreach (var i in pf.shopItems)
            {
                if(i != null)
                {
                    Destroy(i.gameObject);
                }
            }

            shopDisplay.SetActive(false);
            inventory.SetActive(false);
        }
    }
}
