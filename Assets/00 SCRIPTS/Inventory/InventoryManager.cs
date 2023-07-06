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
            for(int i=0;i<playerInventory.myInventory.Count;i++)
            {
               
                GameObject temp= Instantiate(blankInventorySlot,
                    inventoryPanel.transform.position,Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot=temp.GetComponent<InventorySlot>();
                  if(newSlot)
                newSlot.Setup(playerInventory.myInventory[i], this);
            }
        }
    }
    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
