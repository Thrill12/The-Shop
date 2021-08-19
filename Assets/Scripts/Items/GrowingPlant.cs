using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlant : MonoBehaviour
{
    public BaseItem plantToGive;
    public float timeStepToGrow;
    public bool isReady = false;

    private PrefabManager pf;
    private Planter planter;
    private AudioClipLibrary audioLib;

    private void Start()
    {
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
        GetComponent<SpriteRenderer>().sprite = plantToGive.itemIcon;
        planter = GameObject.FindGameObjectWithTag("Player").GetComponent<Planter>();
        audioLib = planter.gameObject.GetComponentInChildren<AudioClipLibrary>();
    }

    // Update is called once per frame
    public IEnumerator GrowPlant()
    {
        GetComponentInParent<AudioSource>().Play();
        transform.localScale = Vector3.zero;
        while (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            yield return new WaitForSeconds(timeStepToGrow);
        }
        isReady = true;
        planter.occupiedPlaces.Remove(transform.position);
        GetComponentInParent<AudioSource>().Stop();
        GetComponentInParent<AudioSource>().PlayOneShot(audioLib.growableReady);
        GetComponent<Animator>().SetTrigger("Ready");
        yield return null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && isReady)
        {
            pf.SpawnUIItem(plantToGive);
            pf.SpawnUIItem(plantToGive);
            GetComponentInParent<AudioSource>().PlayOneShot(audioLib.growablePickup);
            Destroy(gameObject);
        }
    }
}
