using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    

    [SerializeField] float thrust;
    [SerializeField] float knockTime;
    [SerializeField] float damage;

    public float Damage { get => damage; set => damage = value; }

    //[SerializeField] Enemy_State currentState;
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
                
                Vector3 dir = (other.transform.position - this.transform.position).normalized * thrust;
                rigi.AddForce(dir, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") )
                {

                    //CameraController.Instant.BeginKick();
                    //currentState = Enemy_State.Stagger;
                   

                        other.gameObject.GetComponent<EnemyBase>().TakeDamage(Damage);
                        other.gameObject.GetComponent<EnemyBase>().Knock( knockTime);
                    
                }
                if (other.gameObject.CompareTag("Player") )
                {
              

                    //Debug.LogError(other.gameObject.name);
                    other.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
                    other.gameObject.GetComponent<PlayerController>().Knock(knockTime);
                }


                //

                //
                //StartCoroutine(KnockCo(rigi));

            }
        }
    }
    //IEnumerator KnockCo(Rigidbody2D rigi)
    //{
    //    if(rigi != null)
    //    {
    //        yield return new WaitForSeconds(knockTime);
    //        rigi.velocity= Vector2.zero;
            
    //    }
    //}
}
