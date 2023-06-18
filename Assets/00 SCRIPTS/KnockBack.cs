using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerData _playerData;
    [SerializeField] float thrust;
    [SerializeField] float knockTime;
    [SerializeField] float damage;
    [SerializeField] Enemy_State currentState;
    void Start()
    {
        thrust=_playerData.thrust;
        knockTime = _playerData.knockTime;
        damage=_playerData.damage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInParent<EnemyController>().setState(Enemy_State.Stagger);
            other.gameObject.GetComponentInParent<EnemyController>().TakeDamage(damage);

            Rigidbody2D rigi =other.GetComponent<Rigidbody2D>();
          
            if (rigi!=null)
            {
                //rigi.isKinematic = false;
                Vector2 dir = (other.transform.position - this.transform.position).normalized* thrust;
                rigi.AddForce(dir,ForceMode2D.Impulse);
                other.gameObject.GetComponentInChildren<SpriteRenderer>().color= Color.red;
         
                StartCoroutine(KnockCo(rigi, other.gameObject));

            }
        }
    }
    IEnumerator KnockCo(Rigidbody2D enemy,GameObject other)
    {
        if(enemy!=null)
        {
            

            yield return new WaitForSeconds(knockTime);
            other.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            enemy.velocity= Vector2.zero;
            //other.gameObject.GetComponent<EnemyController>().setState(Enemy_State.Walk);
            //other.gameObject.SetActive(false);
            //enemy.isKinematic=true;
        }
    }
}
