using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbilityBase
{
    // Start is called before the first frame update
    public float dashVelocity;
    public override void Activate(GameObject parent)
    {
        Debug.Log("hello");
         
        Rigidbody2D rigi= PlayerController.Instant.gameObject.GetComponent<Rigidbody2D>();
        rigi.velocity = PlayerController.Instant.Movement * dashVelocity;

    }
}
