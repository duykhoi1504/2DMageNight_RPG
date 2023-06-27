using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Enemy_State
{
    Idle,
    Attack,
    Walk,
    Stagger,
    Dead,
}
public class EnemyBase : MonoBehaviour
{
    [SerializeField] Enemy_State EnemyState;
  
    private float health;
    private float damage;
    private float speed;
    private float chaseRadius;
    private float attackRadius;
  
    Vector3 movoment;
    float distance;

    public Enemy_State EnemyState1 { get => EnemyState; set => EnemyState = value; }
  
    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public float ChaseRadius { get => chaseRadius; set => chaseRadius = value; }
    public float AttackRadius { get => attackRadius; set => attackRadius = value; }
    public Vector3 Movoment { get => movoment; set => movoment = value; }
    public float Distance { get => distance; set => distance = value; }
    public float Health { get => health; set => health = value; }

    public Enemy_State getState()
    {
        return EnemyState;
    }
    public void setState(Enemy_State state)
    {
        EnemyState = state;

    }
    public void CheckDistance(GameObject player,Rigidbody2D rigi)
    {

        Vector3 dir = player.transform.position - this.transform.position;
        Debug.DrawRay(this.transform.position, dir, Color.red);
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        movoment = rigi.velocity;
        if (distance <= chaseRadius && distance > attackRadius)
        {
            if (EnemyState == Enemy_State.Idle || EnemyState == Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
            //EnemyState = Enemy_State.Walk;
            {
                this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);
                ChangeState(Enemy_State.Walk);
            }
            //else if (movoment != Vector3.zero && EnemyState == Enemy_State.Stagger)
            //    ChangeState(Enemy_State.Walk);
            else if (movoment == Vector3.zero && EnemyState != Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
                ChangeState(Enemy_State.Idle);

        }
        else
            ChangeState(Enemy_State.Idle);
        if (EnemyState == Enemy_State.Stagger)
        {
            ChangeState(Enemy_State.Walk);
        }
    }
   
   
    public void ChangeState(Enemy_State state)
    {
        if (EnemyState != state)
        {
            EnemyState = state;
        }
    }
    public void UpSacle(GameObject player)
    {
        Vector3 dir = player.transform.position - this.transform.position;

        if (dir.x > 0)
            this.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        else if (dir.x < 0)
            this.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        else return;
    }


    public void Knock(Rigidbody2D _rigi, float knockTime)
    {
        if (this.gameObject.activeSelf)
        {
            setState(Enemy_State.Stagger);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            StartCoroutine(KnockCo(_rigi, knockTime));
        }
    }
    IEnumerator KnockCo(Rigidbody2D _rigi, float knockTime)
    {
        if (_rigi != null)
        {
            yield return new WaitForSeconds(knockTime);
            setState(Enemy_State.Idle);

            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            _rigi.velocity = Vector3.zero;

        }
    }
}
