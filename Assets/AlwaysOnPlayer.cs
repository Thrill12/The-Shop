using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysOnPlayer : MonoBehaviour
{
    public Vector2 vector;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)player.transform.position + vector;
    }
}
