using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlant : MonoBehaviour
{
    public Plant plantToGive;
    private float timeStepToGrow;
    public bool isReady = false;

    private PrefabManager pf;
    private Planter planter;
    private AudioClipLibrary audioLib;
    private AudioSource src;

    private void Start()
    {
        pf = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
        GetComponentInChildren<SpriteRenderer>().sprite = plantToGive.itemIcon;
        planter = GameObject.FindGameObjectWithTag("Player").GetComponent<Planter>();
        audioLib = planter.gameObject.GetComponentInChildren<AudioClipLibrary>();
        src = GetComponent<AudioSource>();
        timeStepToGrow = plantToGive.growStepTime;
    }

    // Update is called once per frame
    public IEnumerator GrowPlant()
    {
        GetComponent<AudioSource>().Play();
        transform.localScale = Vector3.zero;
        while (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            yield return new WaitForSeconds(timeStepToGrow);
        }
        isReady = true;
        
        src.Stop();
        src.volume = 0.7f;
        src.PlayOneShot(audioLib.growableReady);
        GetComponentInChildren<Animator>().SetTrigger("Ready");
        yield return null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && isReady)
        {
            audioLib.gameObject.GetComponent<AudioSource>().PlayOneShot(audioLib.growablePickup);
            pf.SpawnUIItem(plantToGive);
            pf.SpawnUIItem(plantToGive);
            planter.occupiedPlaces.Remove(transform.position);
            Destroy(gameObject);
        }
    }
}
