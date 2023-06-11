using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
    Walk,
    Attack,
}
public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] float speed = 4f;
    Rigidbody2D rigi;
    Vector3 movement=Vector3.zero;
    public Player_State PlayerState;
    // Start is called before the first frame update
    void Start()
    {
       rigi=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rigi.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) * speed;
        if (rigi.velocity.x > 0)
        {
            PlayerState = Player_State.Walk;
        }
        
    }
}
