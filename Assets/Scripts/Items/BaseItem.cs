using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;    
    public float itemValue;
    public bool isEquipped = false;
}
