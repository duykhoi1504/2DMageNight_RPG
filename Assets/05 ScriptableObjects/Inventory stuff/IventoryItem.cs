using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item", menuName ="Iventory/Items")]
public class IventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDesciption;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
}
