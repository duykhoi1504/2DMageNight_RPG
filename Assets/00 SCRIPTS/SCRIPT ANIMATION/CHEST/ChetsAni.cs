using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum Chest_State
{
   Idle,
    OpenChest,
    CloseChest,
}
public class ChetsAni : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite openChest;
    [SerializeField] Sprite closeChest;
    [SerializeField] bool isOpen=false;
    Animator ani;
    [SerializeField] Chest_State ChestState;
    SpriteRenderer spriteAni;
    void Start()
    {
        ani=this.GetComponent<Animator>();
        spriteAni= this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
            if (isOpen)
                    ani.SetBool("Open", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))     
                isOpen = true;             
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                isOpen = false;
            ani.SetBool("Open", false);
         
        }
    }
}
