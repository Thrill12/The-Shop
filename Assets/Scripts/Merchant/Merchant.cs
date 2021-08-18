using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject shopDisplay;
    public GameObject inventory;

    private void Start()
    {
        shopDisplay.SetActive(false);
        inventory.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            shopDisplay.SetActive(true);
            inventory.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            shopDisplay.SetActive(false);
            inventory.SetActive(false);
        }
    }
}
