using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    

    [SerializeField] float thrust;
    [SerializeField] float knockTime;
    [SerializeField] float damage;
    [SerializeField] Enemy_State currentState;
    void Start()
    {
        //thrust=_playerData.thrust;
        //knockTime = _playerData.knockTime;
        //damage=_playerData.damage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigi =other.GetComponentInParent<Rigidbody2D>();
            if (rigi!=null)
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    currentState = Enemy_State.Stagger;
                    other.gameObject.GetComponentInParent<EnemyController>().setState(currentState);
                    other.gameObject.GetComponentInParent<EnemyController>().TakeDamage(damage);
                 
                }
                //rigi.isKinematic = false;
                Vector2 dir = (other.transform.position - this.transform.position).normalized* thrust;
                rigi.AddForce(dir,ForceMode2D.Impulse);
                
                //
                
                //
                StartCoroutine(KnockCo(rigi));

            }
        }
    }
    IEnumerator KnockCo(Rigidbody2D rigi)
    {
        if(rigi != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigi.velocity= Vector2.zero;
            //other.gameObject.GetComponent<EnemyController>().setState(Enemy_State.Walk);

            //enemy.isKinematic=true;
        }
    }
}
