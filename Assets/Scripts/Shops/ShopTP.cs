using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTP : MonoBehaviour
{
    public GameObject placeToTP;

    public GameObject textPrompt;

    private GameObject player;

    private bool canTP;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TPToPlace()
    {
        player.transform.position = placeToTP.transform.position;
        player.GetComponent<Planter>().isInShop = !player.GetComponent<Planter>().isInShop;
    }

    private void Update()
    {
        if(canTP && Input.GetKeyDown(KeyCode.F))
        {
            TPToPlace();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            canTP = true;
            textPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            canTP = false;
            textPrompt.SetActive(false);
        }
    }
}
