using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float inputX;
    public float inputY;

    public Vector2 mousePos;

    public Vector2 movementVector;

    public void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        movementVector = new Vector2(inputX, inputY);
    }
}
