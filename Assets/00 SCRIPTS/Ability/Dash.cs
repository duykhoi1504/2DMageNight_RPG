using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : AbilityBase
{
    // Start is called before the first frame update
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
       
         
        //Rigidbody2D rigi= PlayerController.Instant.gameObject.GetComponent<Rigidbody2D>();
        //rigi.velocity = PlayerController.Instant.Movement * dashVelocity;
        PlayerController.Instant.Speed= dashVelocity;
        PlayerController.Instant.mana -= 2f;

    }
    public override void BeginCoolDown(GameObject parent) 
    {

        PlayerController.Instant.Speed = PlayerController.Instant.NormalSpeed;
    }
}
