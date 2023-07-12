using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
    //public Item contents;
    //public Inventory playerInventory;

    public bool isOpen;
    public bool playerInrange;
    
    //public GameObject dialogWindow;
    //public GameObject diaLogText;
    [SerializeField] GameObject item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerInrange)
        {
            AudioManager.Instant.PLaySFX(CONSTANT.chest);

            if (!isOpen)
            {
                OpenChest();
            }
            //else
            //{
            //    ChestAlreadyOpem();
            //}
        }
    }
   public void OpenChest()
    {
        //playerInventory.AddItem(contents);
        GameObject _item= Instantiate(item,this.transform.position, Quaternion.identity);
        _item.transform.localPosition += new Vector3(0f, 1f, 0f);
        //Debug.Log("its a"+ contents.itemDescription);
        //playerInventory.currentItem= contents;
       
        isOpen= true;
    }
    public void ChestAlreadyOpem()
    {
        //playerInventory.currentItem= null;
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
