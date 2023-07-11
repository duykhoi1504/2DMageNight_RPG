using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu]
public class FireBall : AbilityBase
{
    ObjectPoolingX<FireBall>   _fireBall;
    [SerializeField] GameObject bullet;
   
    // Start is called before the first frame update
    GameObject temp;
    public override void Activate(GameObject parent)
    {
       


        GameObject g2 =Instantiate(bullet, parent.transform.position, Quaternion.identity);


        //g2.transform.rotation = parent.transform.rotation;
        //g2.transform.position = parent.transform.position;
        g2.SetActive(true);
       
    }
    public override void BeginCoolDown(GameObject parent)
    {
       
    }
}
