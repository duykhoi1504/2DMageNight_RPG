using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAni :AniBase
{
    // Start is called before the first frame update
    Animator ani;
    [SerializeField] Enemy_State EnemyState;

   
    void Start()
    {
        ani= GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
       
  ani.SetTrigger(EnemyState.ToString());
            
    }
}
