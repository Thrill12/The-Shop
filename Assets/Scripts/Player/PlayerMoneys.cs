using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoneys : MonoBehaviour
{
    public int coins;

    public TMP_Text coinsDisplay;
    public GameObject inventory;

    private void Update()
    {
        coinsDisplay.text = coins.ToString();

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }
}
