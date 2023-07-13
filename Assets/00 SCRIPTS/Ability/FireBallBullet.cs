using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigi;
    [SerializeField] float speed;
    [SerializeField] GameObject effect;
    [SerializeField] float timeStop;
    [SerializeField] float timeCout = 0;
    void Start()
    {
        float timeCout = 0;

        rigi = this.GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject,2f);

    }

    // Update is called once per frame
    void Update()
    {
        timeCout += Time.deltaTime;
        if (timeCout > timeStop) 
        { 
            this.gameObject.SetActive(false);
            timeCout = 0;
        }
        rigi.velocity = this.transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            GameObject ef = Instantiate(effect, collision.transform.position, Quaternion.identity);
            ef.transform.position += new Vector3(0f, 1f, 0f);
            Destroy(ef, 1f);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
  
}
