using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


[CreateAssetMenu]
public class FireBall : AbilityBase
{
    
    [SerializeField] GameObject bullet;
    //[SerializeField] float speedSpell;
   
    // Start is called before the first frame update
 
    public override void Activate(GameObject parent)
    {
        if (PlayerController.Instant.mana <= 0) return;
        PlayerController.Instant.mana -= 2f;
        Vector2 player = PlayerController.Instant.transform.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 dir = ((Vector2)mouse - player).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        AudioManager.Instant.PLaySFX(CONSTANT.arrow);

        //GameObject fireball = Instantiate(bullet, parent.transform.position, Quaternion.identity);
        GameObject fireball=OPManager.Instant.gameObject.GetComponent<OPManager>().GetObject(bullet);
        fireball.transform.position = parent.transform.position;
        fireball.transform.rotation= rotation;
        fireball.SetActive(true);


    }
    public override void BeginCoolDown(GameObject parent)
    {
       
    }
}
