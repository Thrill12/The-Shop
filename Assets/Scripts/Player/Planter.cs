using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public GameObject currentlySelected;

    private InputManager input;

    private void Start()
    {
        input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
    }

    public void Update()
    {
        currentlySelected.transform.position = new Vector2(Mathf.RoundToInt(input.mousePos.x), Mathf.RoundToInt(input.mousePos.y));

        if (Input.GetMouseButton(0) && currentlySelected != null)
        {
            currentlySelected = null;
        }
    }
}
