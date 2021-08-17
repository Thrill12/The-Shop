using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float inputX;
    public float inputY;

    public Vector2 movementVector;

    public void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        movementVector = new Vector2(inputX, inputY);
    }
}
