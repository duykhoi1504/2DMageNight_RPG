using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AniBase : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("StateMachine")]
    public Enemy_State oldState;


    [SerializeField] EnemyBase enemy;
    Rigidbody2D rigi;
    Animator ani;

    // Update is called once per frame
    private void Start()
    {
        enemy=this.GetComponentInParent<EnemyBase>();
        rigi=this.GetComponentInParent<Rigidbody2D>();
        ani=this.GetComponent<Animator>();
        
    }
    
    public void changeAni(Enemy_State state)
    {
        if (state == oldState) return;
        ani.SetTrigger(state.ToString());
        oldState=state;
    }

    public  void UpSacle()
    {

        Vector3 dir = PlayerController.Instant.gameObject.transform.position - this.transform.position;
        float distance = Vector3.Distance(this.transform.position, PlayerController.Instant.transform.position);
        if (distance <= enemy.ChaseRadius)
        {

            if (dir.x > 0)
                this.transform.localScale = new Vector3(1f, 1f, 1);
            else if (dir.x < 0)
                this.transform.localScale = new Vector3(-1f, 1f, 1);
            else return;
        }
        else
        {
            if (rigi.velocity.x > 0)
                this.transform.localScale = new Vector3(1f, 1f, 1);
            else if (rigi.velocity.x < 0)
                this.transform.localScale = new Vector3(-1f, 1f, 1);
            else return;
        }
    }
   
}
