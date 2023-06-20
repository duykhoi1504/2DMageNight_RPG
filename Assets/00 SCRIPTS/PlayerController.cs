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
       rigi=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rigi.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) * speed;
        movement = rigi.velocity;
        if (movement!=Vector3.zero)
        {
            PlayerState = Player_State.Walk;
        }
        else if(movement == Vector3.zero)
        {
            PlayerState = Player_State.Idle;
        }
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            float damage = collision.gameObject.GetComponent<EnemyController>().damage;
            Debug.Log(damage);
            if(health>=0)
                health -= damage;
        }

    }
   
}
