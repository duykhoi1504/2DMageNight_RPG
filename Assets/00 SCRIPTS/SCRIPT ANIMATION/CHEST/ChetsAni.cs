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

      


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChestState = Chest_State.OpenChest;
            //ani.enabled = true;
            ani.SetBool("Close", true);
            //changeAni(Chest_State.OpenChest);
            //StartCoroutine(ChangeAiCo());

        

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChestState = Chest_State.CloseChest;
            ani.enabled = true;

            //changeAni(Chest_State.CloseChest);

            //StartCoroutine(ChangeAiCo());
            ani.SetBool("Open", false);

        }
    }
    void changeAni(Chest_State state)
    {
        ani.SetTrigger(state.ToString());
        
    }        
   IEnumerator ChangeAiCo()
    {
        yield return new WaitForSeconds(0.2f);
        ani.enabled = false;
        if (ChestState == Chest_State.OpenChest)
        {
            spriteAni.sprite = openChest;
        }else if(ChestState == Chest_State.CloseChest)
            spriteAni.sprite = closeChest;


    }
}
