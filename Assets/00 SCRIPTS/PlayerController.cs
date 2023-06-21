using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
    Idle,
    Walk,
    Attack,
}
public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] float speed = 4f;
    [SerializeField] PlayerData _playerData;
    [SerializeField] FloatValue _HeartManager;
    Rigidbody2D rigi;
    Vector3 movement;
    public float health;
    public Player_State PlayerState;
    // Start is called before the first frame update
    void Start()
    {
        health = _playerData.Health;
        speed = _playerData.speed;
        rigi = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {

        //rigi.velocity = new Vector2(
        //    Input.GetAxisRaw("Horizontal"),
        //    Input.GetAxisRaw("Vertical")) * speed;

        //movement = rigi.velocity;

        movement = Vector3.zero;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement != Vector3.zero)
        {
            moveCharacter();
        }

        if (movement != Vector3.zero)
        {
            PlayerState = Player_State.Walk;
        }
        else if (movement == Vector3.zero)
        {
            PlayerState = Player_State.Idle;
        }
      
    }
    public void moveCharacter()
    {
        rigi.MovePosition(transform.position + movement * speed*Time.deltaTime);
    }
    public void Knock( float knockTime)
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        
        StartCoroutine(KnockCo( knockTime));
        

    }
    IEnumerator KnockCo( float knockTime)
    {
        if (rigi != null)
        {
            yield return new WaitForSeconds(knockTime);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            rigi.velocity = Vector3.zero;
            
        }
    }
    public void TakeDamage(float damage)
    {

        if (health >= 0)
            health -= damage;
    }

}
