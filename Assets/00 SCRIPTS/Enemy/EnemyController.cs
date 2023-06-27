using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : EnemyBase
{

    // Start is called before the first frame update
    //[SerializeField] Enemy_State EnemyState;
    [SerializeField] EnemyHealth MaxHealth;
    //public float Health;
    //public float damage;
    //AniBase Animator;
    [SerializeField] GameObject player;
    Rigidbody2D rigi;
    //ScriptanleObjects
    //[SerializeField] float speed;
    //[SerializeField] float chaseRadius;
    //[SerializeField] float attackRadius;
    [SerializeField] GameObject deadEffect;
    [SerializeField] LootTable thisLoop;
    //Vector3 movoment ;
    //float distance;

    void Start()
    {

        //ScriptableObject
        Damage= MaxHealth.damage;
        Health = MaxHealth.Health;
        Speed = MaxHealth.speed;
        ChaseRadius = MaxHealth.chaseRadius;
        AttackRadius = MaxHealth.attackRadius;
        
        //
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        rigi = this.gameObject.GetComponent<Rigidbody2D>();
        //Animator = this.GetComponentInChildren<AniBase>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(player,rigi);
        UpSacle(player);
        //Debug.Log(EnemyState.ToString());

    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
         MakeLoop();
        if (Health <= 0)
        {
            this.gameObject.SetActive(false);
            
            DeadEffect();
           
        }
    }
    private void MakeLoop()
    {
        if (thisLoop != null)
        {
            PowerUp current = thisLoop.LootPowerUp();
            if(current != null)
            {
                Instantiate(current.gameObject,transform.position,Quaternion.identity);
            }
        }
    }
    public void DeadEffect()
    {
        if (deadEffect != null)
        {
            GameObject effect = Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
    //public Enemy_State getState()
    //{
    //    return EnemyState;
    //}
    //public void setState(Enemy_State state)
    //{
    //    EnemyState = state;

    //}
    //private void CheckDistance()
    //{

    //    Vector3 dir = player.transform.position - this.transform.position;
    //    Debug.DrawRay(this.transform.position, dir, Color.red);
    //    distance = Vector3.Distance(this.transform.position, player.transform.position);
    //    movoment = rigi.velocity;
    //    if (distance <= chaseRadius && distance > attackRadius)
    //    {
    //        if (EnemyState == Enemy_State.Idle || EnemyState == Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
    //        //EnemyState = Enemy_State.Walk;
    //        {
    //            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);
    //            ChangeState(Enemy_State.Walk);
    //        }
    //        //else if (movoment != Vector3.zero && EnemyState == Enemy_State.Stagger)
    //        //    ChangeState(Enemy_State.Walk);
    //        else if (movoment == Vector3.zero && EnemyState != Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
    //            ChangeState(Enemy_State.Idle);

    //    }
    //     else
    //        ChangeState(Enemy_State.Idle);
    //     if ( EnemyState == Enemy_State.Stagger) {
    //        ChangeState(Enemy_State.Walk);
    //    }
    //}
    //public void TakeDamage(float damage)
    //{
    //    Health-= damage;
    //    if (Health <= 0)
    //    {
    //        this.gameObject.SetActive(false);
    //        DeadEffect();
    //    }
    //}
    //public void DeadEffect()
    //{
    //    if (deadEffect != null)
    //    {
    //        GameObject effect = Instantiate(deadEffect, transform.position, Quaternion.identity);
    //        Destroy(effect, 1f);
    //    }
    //}
    //public void ChangeState(Enemy_State state)
    //{
    //    if (EnemyState != state)
    //    { 
    //        EnemyState = state;
    //    }
    //}
    //public void UpSacle()
    //{
    //    Vector3 dir = player.transform.position - this.transform.position;

    //    if (dir.x > 0)
    //        this.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    //    else if (dir.x < 0)
    //        this.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
    //}


    //public void Knock(Rigidbody2D _rigi, float knockTime)
    //{
    //    if (this.gameObject.activeSelf)
    //    {
    //        setState(Enemy_State.Stagger);
    //        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    //        StartCoroutine(KnockCo(_rigi, knockTime));
    //    }
    //}
    //IEnumerator KnockCo(Rigidbody2D _rigi, float knockTime)
    //{
    //    if (_rigi != null)
    //    {
    //        yield return new WaitForSeconds(knockTime);
    //        setState(Enemy_State.Idle);

    //        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    //        rigi.velocity = Vector3.zero;

    //    }
    //}


}
