using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu, System.Serializable]
public class Plant : BaseItem
{
    public GameObject plant;
    public float growStepTime = 0.5f;
}
