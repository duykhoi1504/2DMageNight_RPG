using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skeleton : EnemyBase
{
    public override void CheckDistance()
    {

        Vector3 dir = target.transform.position - this.transform.position;
        Debug.DrawRay(this.transform.position, dir, Color.red);
        Distance = Vector3.Distance(this.transform.position, target.transform.position);
        movement = rigi.velocity;
        if (Distance <= ChaseRadius && Distance > AttackRadius)
        {

            if (EnemyState == Enemy_State.Idle || EnemyState == Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
            //EnemyState = Enemy_State.Walk;
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, Speed * Time.deltaTime);
                ChangeState(Enemy_State.Walk);
            }
            //else if (movoment != Vector3.zero && EnemyState == Enemy_State.Stagger)
            //    ChangeState(Enemy_State.Walk);


        }
        else if (Distance <= ChaseRadius && Distance <= AttackRadius)
        {
            if (EnemyState == Enemy_State.Idle || EnemyState == Enemy_State.Walk && EnemyState != Enemy_State.Stagger)
                ChangeState(Enemy_State.Attack);
        }
        else
        {
            if(movement==Vector3.zero)
            ChangeState(Enemy_State.Idle);
            if (movement != Vector3.zero)
                ChangeState(Enemy_State.Walk);
        }


    }
    IEnumerator AttackCo()
    {
        ChangeState(Enemy_State.Attack);
        yield return new WaitForSeconds(2f);
        ChangeState(Enemy_State.Walk);
        rigi.velocity = Vector3.zero;
    }
    
}
