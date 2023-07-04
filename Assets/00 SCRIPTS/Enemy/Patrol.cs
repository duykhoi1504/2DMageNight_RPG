using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Patrol : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField]EnemyBase enemyBase;
    GameObject player;
    [SerializeField] GameObject currentGoal;
    public float rouningDistance;
    [SerializeField]string textPlace;
  
    private Rigidbody2D rigi;
    [SerializeField]  float speed=0.5f;
     Vector2 randomVector;
      float timer=0;
     float timerToSleep=0;
    float timeToChangeDir = 2f;
    [SerializeField] float randomTimer;
     void Start()
    {
        enemyBase=GetComponent<EnemyBase>();
        randomTimer = Random.Range(1, 8);

        //GameObject place = GameObject.FindGameObjectWithTag(textPlace);

        rigi = this.gameObject.GetComponent<Rigidbody2D>();
        SetRandomVector();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    void Update()
    {
        
        timerToSleep += Time.deltaTime;//check time for enemy idle
        timer += Time.deltaTime;
        
        CheckDistance();
        
    }
    private void CheckDistance()
    {
        //    changeRandomDir();
        // Kiểm tra khoảng cách giữa enemy và vị trí ban đầu
        float distanceToOriginal = Vector3.Distance(transform.position, currentGoal.transform.position);
        if (distanceToOriginal > rouningDistance)
        {
            // Di chuyển enemy về vị trí ban đầu
            rigi.velocity = (currentGoal.transform.position - transform.position).normalized * speed;
            //return;
            enemyBase.ChangeState(Enemy_State.Walk);

        }
        else
        {
            
            changeRandomDir();
          
        }
        // Tiếp tục di chuyển ngẫu nhiên nếu không vượt quá ngưỡng khoảng cách


    }
    void changeRandomDir()
    {
        
        if (timerToSleep < randomTimer)
        {
            if (timer >= timeToChangeDir)
            {
                SetRandomVector();
                timer = 0f;
            }
            if (rigi.velocity.magnitude < randomVector.magnitude)
            {
                enemyBase.ChangeState(Enemy_State.Walk);
                rigi.velocity = randomVector * speed;
            }
        }
        else if (timerToSleep > randomTimer)
            rigi.velocity = Vector2.zero;
        if (timerToSleep > randomTimer+4f)
            timerToSleep = 0f;

    }
    private void SetRandomVector()
    {
        randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
  
}
