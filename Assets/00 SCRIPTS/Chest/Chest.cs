using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
    public Item contents;
    public Inventory playerInventory;

    public bool isOpen;
    public bool playerInrange;

    public GameObject dialogWindow;
    public GameObject diaLogText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerInrange)
        {
            if(!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpem();
            }
        }
    }
   public void OpenChest()
    {
        playerInventory.AddItem(contents);
        playerInventory.currentItem= contents;
       
        isOpen= true;
    }
    public void ChestAlreadyOpem()
    {
        playerInventory.currentItem= null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerInrange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInrange = false;

        }
    }
   
}
