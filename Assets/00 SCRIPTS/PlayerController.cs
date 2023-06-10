using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Rigidbody2D rigi;
    Vector3 movement=Vector3.zero;
    
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

        
    }
}
