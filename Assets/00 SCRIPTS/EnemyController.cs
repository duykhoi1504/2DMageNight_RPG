using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy_State
{
    Idle,
    Attack,
    Walk,
    Stagger,
    Dead,
}
public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] Enemy_State EnemyState;
    [SerializeField] EnemyHealth MaxHealth;
    public float Health;
    AniBase Animator;
    [SerializeField] GameObject player;
    Rigidbody2D rigi;
    //ScriptanleObjects
    [SerializeField] float speed;
    [SerializeField] float chaseRadius;
    [SerializeField] float attackRadius;
    Vector3 movoment ;
    float distance;
    
    void Start()
    {
        //ScriptableObject
        Health = MaxHealth.Health;
        speed = MaxHealth.speed;
        chaseRadius = MaxHealth.chaseRadius;
        attackRadius = MaxHealth.attackRadius;
        
        //
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        rigi = this.GetComponent<Rigidbody2D>();
        Animator = this.GetComponentInChildren<AniBase>();
    }

    // Update is called once per frame
    void Update()
    {
       


        CheckDistance();
        UpSacle();
        Debug.Log(EnemyState.ToString());

    }
    public Enemy_State getState()
    {
        return EnemyState;
    }
    public void setState(Enemy_State state)
    {
        EnemyState = state;
    }
    private void CheckDistance()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Debug.DrawRay(this.transform.position, dir, Color.red);
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (distance <= chaseRadius && distance > attackRadius)
        {
            //if (EnemyState == Enemy_State.Idle || EnemyState == Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
            //EnemyState = Enemy_State.Walk;
            
                this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);
                ChangeState(Enemy_State.Walk);
            
        }
        else
        {
            movoment = rigi.velocity;
            if (movoment == Vector3.zero)
                ChangeState(Enemy_State.Idle);
        }
    }
    public void TakeDamage(float damage)
    {
        Health-= damage;
        if (Health <= 0)
            this.gameObject.SetActive(false); 
    }
    private void ChangeState(Enemy_State state)
    {
        if (EnemyState != state)
        { 
            EnemyState = state;
        }
    }
    public void UpSacle()
    {
        Vector3 dir = player.transform.position - this.transform.position;
  
        if (dir.x > 0)
            this.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        else if (dir.x < 0)
            this.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
    }
    
}
