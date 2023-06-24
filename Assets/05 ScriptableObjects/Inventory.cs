using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    // Start is called before the first frame update

    public Item currentItem;
    public List<Item> items=new List<Item>();
    public int numberOfKeys;
    public void AddItem(Item item)
    {
        if (item.isKey)
        {
            numberOfKeys++;
        }
        else
            if(!items.Contains(item))//kiểm tra xem item này có trong list items ko
            items.Add(item);

    }
}
