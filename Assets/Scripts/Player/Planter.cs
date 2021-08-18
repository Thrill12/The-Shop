using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public GameObject currentlySelected;

    private InputManager input;

    private PrefabManager pf;

    private void Start()
    {
        input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    public void Update()
    {
        if(currentlySelected != null)
        {
            currentlySelected.transform.position = new Vector2(Mathf.RoundToInt(input.mousePos.x), Mathf.RoundToInt(input.mousePos.y));

            if (Input.GetMouseButton(0) && currentlySelected != null)
            {
                currentlySelected.GetComponentInChildren<GrowingPlant>().StartCoroutine(currentlySelected.GetComponentInChildren<GrowingPlant>().GrowPlant());
                currentlySelected = null;
            }
            if (Input.GetMouseButton(1) && currentlySelected != null)
            {
                pf.SpawnUIItem(currentlySelected.GetComponentInChildren<GrowingPlant>().plantToGive);
                Destroy(currentlySelected);
            }
        }       
    }
}
