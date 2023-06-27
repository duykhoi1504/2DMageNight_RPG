using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    //[SerializeField] float _timeReload;
    float timeCount = 0;
    bool isImmute;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.gameObject.activeSelf == false)
        //    return;

 

        FireBullet();

        timeCount += Time.deltaTime;
    }
    void FireBullet()
    {

        if (!Input.GetMouseButton(0))
        {
            return;
        }

        if (timeCount < 0.5f)
        {
            return;

        }

        Quaternion newRotation =this.transform.rotation* Quaternion.Euler(0f, 0f, -90f);


        Instantiate(bullet,this.transform.position, newRotation);


        bullet.SetActive(true);
        timeCount = 0;
    }
}
