using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAni :MonoBehaviour
{
    // Start is called before the first frame update
    Animator ani;
    [SerializeField] EnemyController enemy;
    [SerializeField]Enemy_State currentState;
   
    void Start()
    {
        ani= GetComponent<Animator>();
        enemy = this.gameObject.GetComponentInParent<EnemyController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentState = enemy.getState();
        ani.SetTrigger(currentState.ToString());    
    }
    
}
