using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Inventory Infomation")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public IventoryItem currentItem;
    public void SetTextAndButton(string description,bool buttonActive)
    {
        descriptionText.text = description;
        if(buttonActive )
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }
    public void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot,
                        inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            } 
        }
    }
   public  void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        Debug.Log("Made Inventory");
        SetTextAndButton("", false );
        
    }

    public void SetupDescriptionAndButton(string newDescriptionString,
        bool isButtonUsable,IventoryItem newItem )
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }
    public void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.USe();
            //clear all if the inventory slots
            ClearInventorySlots();
            //refill all slots with new nubers
            MakeInventorySlots();
            if (currentItem.numberHeld <= 0)
            {
                SetTextAndButton("", false);
            }
        }
    }
}
