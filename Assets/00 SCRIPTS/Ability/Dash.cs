using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class Dash : AbilityBase
{
    // Start is called before the first frame update
    public float dashVelocity;
    public override void Activate(GameObject parent)
    {


     
        if (PlayerController.Instant.mana <= 0) return;
       // PlayerController.Instant.TriggerCollider.enabled= false;
      //  PlayerController.Instant.Collider1.enabled = false;
        AudioManager.Instant.PLaySFX(CONSTANT.roll);
        PlayerController.Instant.Speed= dashVelocity;
        PlayerController.Instant.StartDustParticle();
        PlayerController.Instant.mana -= 2f;

    }
    public override void BeginCoolDown(GameObject parent) 
    {

        PlayerController.Instant.Speed = PlayerController.Instant.NormalSpeed;
     //   PlayerController.Instant.TriggerCollider.enabled = true;
     //   PlayerController.Instant.Collider1.enabled = true;
    }
}
