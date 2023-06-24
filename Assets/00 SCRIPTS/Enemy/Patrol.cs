using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Patrol : MonoBehaviour 
{
    // Start is called before the first frame update
    GameObject player;
    public Transform currentGoal;
    public float rouningDistance;
    [SerializeField]string textPlace;
    private Rigidbody2D rigi;
    [SerializeField]  float speed=0.5f;
     Vector2 randomVector;
     private float timer=0;
     float timeToChangeDir = 2f;

     void Start()
    {
        GameObject place = GameObject.FindGameObjectWithTag(textPlace);
        currentGoal = place.transform;
        rigi = GetComponent<Rigidbody2D>();
        SetRandomVector();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

     void Update()
    {
       
        timer += Time.deltaTime;
        CheckDistance();
        
    }
    private void CheckDistance()
    {
        //if (Vector2.Distance(player.transform.position, this.transform.position) > 5 && isInGround == true)
        //{
        //    isInGround = false;

        //}
        //else if (Vector2.Distance(PointList[0].transform.position, this.transform.position) >= 0 &&
        //    Vector2.Distance(PointList[0].transform.position, this.transform.position) < 5)
        //    isInGround = true;

        //if (!isInGround)
        //    this.transform.position = Vector3.MoveTowards(this.transform.position, PointList[0].transform.position, 1 * Time.deltaTime);
        //if (isInGround)
        //    changeRandomDir();
        // Kiểm tra khoảng cách giữa enemy và vị trí ban đầu
        float distanceToOriginal = Vector3.Distance(transform.position, currentGoal.transform.position);
        if (distanceToOriginal > rouningDistance)
        {
            // Di chuyển enemy về vị trí ban đầu
            rigi.velocity = (currentGoal.transform.position - transform.position).normalized * speed;
            return;

        }
        changeRandomDir();
        // Tiếp tục di chuyển ngẫu nhiên nếu không vượt quá ngưỡng khoảng cách


    }
    void changeRandomDir()
    {
        if (timer >= timeToChangeDir)
        {
            SetRandomVector();
            timer = 0f;
        }
        if (rigi.velocity.magnitude < randomVector.magnitude)
        {
            rigi.velocity = randomVector * speed;
        }
    }
    private void SetRandomVector()
    {
        randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
  
}
