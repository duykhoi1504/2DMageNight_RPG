using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAni :MonoBehaviour
{
    // Start is called before the first frame update
    Animator ani;
    [SerializeField] EnemyController enemy;
    [SerializeField]Enemy_State currentState;
    Rigidbody2D rigi;
    void Start()
    {
        ani= GetComponent<Animator>();
        enemy = this.gameObject.GetComponentInParent<EnemyController>();
        rigi = enemy.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
            UpSacle(PlayerController.Instant.gameObject);
        currentState = enemy.getState();
        ani.SetTrigger(currentState.ToString());    
    }
    public void UpSacle(GameObject player)
    {

        Vector3 dir = player.transform.position - this.transform.position;
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
