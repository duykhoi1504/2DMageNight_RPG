using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
    Idle,
    Walk,
    Attack,
    Stagger
}
public class PlayerController : Singleton<PlayerController>
{
    [Header("PlayerState")]
    public Player_State PlayerState;

    [Header("ProfilePlayer")]
    [SerializeField] float speed = 4f;
    [SerializeField] PlayerData _playerData;
    [SerializeField] FloatValue _HeartManager;
    Rigidbody2D rigi;
    Vector3 movement;
    public float health;
    
    //private float weapon1 = 1;
    [SerializeField]GameObject weap;
    [SerializeField] Inventory playerInventory;
    [SerializeField] SpriteRenderer recieveItemsSprite;

    [Header("IframeFlash")]
    [SerializeField] Color flashColor;
    [SerializeField] Color regularColor;
    [SerializeField] float flashDuration;
    [SerializeField] float numberOfFlash;
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] Collider2D Collider;

    [SerializeField] SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
  
        health = _playerData.Health;
        speed = _playerData.speed;
        rigi = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //cách 1
        //rigi.velocity = new Vector2(
        //    Input.GetAxisRaw("Horizontal"),
        //    Input.GetAxisRaw("Vertical")) * speed;

        
        //cách 2
        movement = Vector3.zero;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //if (movement != Vector3.zero)
        //{
        //    moveCharacter();
        //}
        if (PlayerState == Player_State.Stagger) return;
        rigi.velocity = movement * speed;
       
        //////////////////////
        //if(movement!=Vector3.zero &&    PlayerState != Player_State.Stagger)
        //{
        //    PlayerState = Player_State.Walk;
        //    rigi.velocity = movement * speed;  

        //}else
        //    rigi.velocity = Vector3.zero;

        if (movement != Vector3.zero && PlayerState != Player_State.Stagger)
        {
            PlayerState = Player_State.Walk;

        }
        if (movement == Vector3.zero  && PlayerState!=Player_State.Stagger)
        {
            PlayerState = Player_State.Idle;
        }
        //if( PlayerState == Player_State.Stagger)
        //{
        //    rigi.velocity = Vector3.zero;
        //}
        //changeWeapon();
    }

    ///
    public void raiseItem()
    {
        recieveItemsSprite.sprite = playerInventory.currentItem.itemSprite;
    }
    //public void changeWeapon()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        weapon1 *= -1;

    //    }
    //    if (weapon1 != 1)
    //    {

    //        weap.SetActive(false);
    //    }
    //    else
    //    {
    //        weap.SetActive(true);
    //    }
    //}
    public void TakeDamage(float damage)
    {

        if (health >= 0)
            health -= damage;
    }
    public void Knock( float knockTime)
    {
        //rigi.velocity = Vector3.zero;
        //this.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;
        //this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        
        PlayerState = Player_State.Stagger;
        StartCoroutine(KnockCo( knockTime));
        

    }
    IEnumerator KnockCo( float knockTime)
    {
        if (rigi != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
        //this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        //this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            
            rigi.velocity = Vector3.zero;
            PlayerState = Player_State.Walk;
        }
    }

    IEnumerator FlashCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        Collider.enabled = false;
        while (temp < numberOfFlash)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
        Collider.enabled = true;

    }
}
