using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI Stuff to change")]
    [SerializeField] private Text itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    //public Sprite itemSprite;
    //public int numberHeld;
    //public string itemDescription;
    public IventoryItem thisItem;
    public InventoryManager thisManager;


    public void Setup(IventoryItem newItem,InventoryManager newManger)
    {
        thisItem = newItem;
        thisManager=newManger;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text=thisItem.numberHeld.ToString();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
