using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
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
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Debug.DrawRay(this.transform.position, dir, Color.red);
        distance = Vector3.Distance(this.transform.position, player.transform.position);
       
        if (distance <= chaseRadius && distance> attackRadius)
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);



    }
}
