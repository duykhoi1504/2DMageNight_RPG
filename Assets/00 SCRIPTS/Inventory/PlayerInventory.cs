using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Iventory/Player Inventory")]

public class PlayerInventory : ScriptableObject
{
    // Start is called before the first frame update
    public List<IventoryItem>myInventory=new List<IventoryItem>();
}
