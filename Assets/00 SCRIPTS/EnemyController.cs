using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy_State
{
    Idle,
    Attack,
    Walk,
    stagger,
    Dead,
}
public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Enemy_State EnemyState;
    EnemyAni EnemyAnimation;
    [SerializeField] GameObject player;
    Rigidbody2D rigi;
    [SerializeField] float speed=0.2f;
    [SerializeField] float chaseRadius;
    [SerializeField] float attackRadius;

    float distance;
    void Start()
    {
         player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        rigi = this.GetComponent<Rigidbody2D>();
        EnemyAnimation = GetComponentInChildren<EnemyAni>();
    }

    // Update is called once per frame
    void Update()
    {      
        CheckDistance();
       
    }
    private void CheckDistance()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Debug.DrawRay(this.transform.position, dir, Color.red);
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (distance <= chaseRadius && distance > attackRadius)
        {
            EnemyState= Enemy_State.Walk;
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            EnemyState = Enemy_State.Idle;
        }
    }
}
