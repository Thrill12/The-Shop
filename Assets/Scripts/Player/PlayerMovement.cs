using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Animator anim;
    public InputManager input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (input.inputX < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if(input.inputX > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        if (rb.velocity.magnitude != 0)
        {
            anim.SetBool("IsWalking", true);
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            anim.SetBool("IsWalking", false);
            GetComponent<AudioSource>().enabled = false;
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = input.movementVector * speed;
    }
}
