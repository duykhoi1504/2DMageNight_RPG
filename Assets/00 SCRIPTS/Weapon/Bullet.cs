using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet :MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rig;
    [SerializeField] float _speed;
    float _countTime = 0;
    [SerializeField] float _maxTime ;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        _countTime = _maxTime;
    }



    // Update is called once per frame
    void Update()
    {
        rig.velocity = this.transform.up * _speed;

        _countTime -= Time.deltaTime;

        if (_countTime < 0)
            this.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            //collision.gameObject.SetActive(false);
        }
    }
   

}
