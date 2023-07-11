using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    [SerializeField]AbilityState state;
    // Start is called before the first frame update
    [SerializeField] AbilityBase ability;
    float coolDownTIme;
    float activeTime;
    [SerializeField] KeyCode key;
      
    void Start()
    {
        AbilityState state = AbilityState.ready;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(state==AbilityState.ready)
        {
            if(Input.GetKeyDown(key)) {
                ability.Activate(this.gameObject);
                state = AbilityState.active;
                activeTime = ability.activeTime;
            }
        }
        else if (state == AbilityState.active)
        {
            if (activeTime > 0)
            {
                activeTime -= Time.deltaTime;
            }
            else
            {
                ability.BeginCoolDown(gameObject);
                state = AbilityState.cooldown;
                coolDownTIme = ability.coolDownTime;
            }
        }
        else if(state == AbilityState.cooldown)
        {
            if (coolDownTIme > 0)
            {
                coolDownTIme -= Time.deltaTime;
            }
            else
            {
                state = AbilityState.ready;
                
            }
        }
    }
}
