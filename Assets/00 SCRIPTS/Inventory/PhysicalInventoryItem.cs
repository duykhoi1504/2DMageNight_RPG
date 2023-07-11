using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : PowerUp
{
    // Start is called before the first frame update
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] IventoryItem thisItem;
   
    public void AddItemToInventory()
    {
        if(playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
             
                thisItem.numberHeld +=1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }
}
