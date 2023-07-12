using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Thunder : AbilityBase
{

    [SerializeField] GameObject thunder;
    //[SerializeField] float speedSpell;

    // Start is called before the first frame update

    public override void Activate(GameObject parent)
    {
        if(PlayerController.Instant.mana<=0)return;
        PlayerController.Instant.mana -= 10f;

        AudioManager.Instant.PLaySFX(CONSTANT.thunder);
        GameObject fireball = Instantiate(thunder, parent.transform.position, Quaternion.identity);
        fireball.transform.localPosition += new Vector3(0f, 1f, 0f);
        Destroy(fireball,2f);


    }
    public override void BeginCoolDown(GameObject parent)
    {

    }
}
