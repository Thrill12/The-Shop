using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public GameObject currentlySelected;

    private InputManager input;

    private PrefabManager pf;

    public List<Vector3> occupiedPlaces;

    public bool isInShop = false;

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
                if(!occupiedPlaces.Where(x => x == currentlySelected.transform.position).Any())
                {
                    currentlySelected.GetComponentInChildren<GrowingPlant>().StartCoroutine(currentlySelected.GetComponentInChildren<GrowingPlant>().GrowPlant());
                    occupiedPlaces.Add(currentlySelected.transform.position);
                    currentlySelected = null;
                }
                else
                {
                    gameObject.transform.Find("AudioClipLibrary").GetComponent<AudioSource>().Play();
                }                
            }
            if (Input.GetMouseButton(1) && currentlySelected != null)
            {
                pf.SpawnUIItem(currentlySelected.GetComponentInChildren<GrowingPlant>().plantToGive);
                Destroy(currentlySelected);
            }
        }       
    }
}
