using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlant : MonoBehaviour
{
    public BaseItem plantToGive;
    public float timeStepToGrow;
    public bool isReady = false;

    private void Start()
    {
        transform.localScale = Vector3.zero;

        StartCoroutine(GrowPlant());
    }

    // Update is called once per frame
    public IEnumerator GrowPlant()
    {
        while (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            yield return new WaitForSeconds(timeStepToGrow);
        }
        isReady = true;
        yield return null;
    }
}
