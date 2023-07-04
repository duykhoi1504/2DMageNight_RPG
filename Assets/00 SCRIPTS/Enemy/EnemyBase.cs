using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum Enemy_State
{
    Idle,
    Attack,
    Walk,
    React,
    Stagger,
    Dead,

}
public class EnemyBase :MonoBehaviour
{
    [SerializeField] protected Enemy_State EnemyState;
    [SerializeField] private string enemyName;
    [SerializeField]  float maxHealth;

    [SerializeField] float health;
    private float damage;
    [SerializeField]private float speed;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] float distance;
    [SerializeField] protected Rigidbody2D rigi;
    [SerializeField]protected Transform target;
    [SerializeField] GameObject deadEffect;
    [SerializeField] LootTable thisLoop;
    [SerializeField ] AniBase _ani;
    protected Vector3 movement;
    [SerializeField] Text textName;
   
    public float Health { get => health; set => health = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public float ChaseRadius { get => chaseRadius; set => chaseRadius = value; }
    public float AttackRadius { get => attackRadius; set => attackRadius = value; }
    public float Distance { get => distance; set => distance = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    private void Start()
    {
        textName.text= enemyName;
        health = MaxHealth;
        rigi = GetComponent<Rigidbody2D>();
        _ani = this.GetComponentInChildren<AniBase>();
        target = PlayerController.Instant.gameObject.GetComponent<Transform>();
    }
    private void Update()
    {

        CheckDistance();
        updateAni();
    }



    public Enemy_State getState()
    {
        return EnemyState;
    }

    public void updateAni()
    {
        _ani.changeAni(EnemyState);
    }

    public virtual void CheckDistance()
    {

    }


    public void ChangeState(Enemy_State state)
    {
        
        if (EnemyState != state)
        {
            EnemyState = state;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {

            this.gameObject.SetActive(false);
            MakeLoop();

            DeadEffect();

        }
    }
    private void MakeLoop()
    {
        if (thisLoop != null)
        {
            PowerUp current = thisLoop.LootPowerUp();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
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
    /////// /////// /////// /////// /////// /////// /////// ///////
    public  void Knock( float knockTime)
    {
        if (this.gameObject.activeSelf)
        {
            
            StartCoroutine(KnockCo( knockTime));
        }
    }
    public IEnumerator KnockCo(float knockTime)
    {
        
            ChangeState(Enemy_State.Stagger);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(knockTime);
            ChangeState(Enemy_State.Idle);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            rigi.velocity = Vector3.zero;

        
    }
}
