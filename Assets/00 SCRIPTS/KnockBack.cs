using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float thrust;
    [SerializeField] float knockTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rigi=other.GetComponent<Rigidbody2D>();
            if(rigi!=null)
            {
                //rigi.isKinematic = false;
                Vector2 dir = (other.transform.position - this.transform.position).normalized* thrust;
                rigi.AddForce(dir,ForceMode2D.Impulse);
                StartCoroutine(KnockCo(rigi));
            }
        }
    }
    IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy!=null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity= Vector2.zero;
            //enemy.isKinematic=true;
        }
    }
}
