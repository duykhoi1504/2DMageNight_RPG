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
    float coolDownTIme;
    float activeTime;


    [Header("Ability")]
    public AbilityBase[] abilities;
    private AbilityBase currentAbility;
    KeyCode keyTemp;
    void Start()
    {
        AbilityState state = AbilityState.ready;
     
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Chuyển sang khả năng đầu tiên trong danh sách
            SetCurrentAbility(0);
            keyTemp = KeyCode.LeftShift;
        }
        else if (Input.GetKey(KeyCode.V))
        {
            // Chuyển sang khả năng thứ hai trong danh sách
            SetCurrentAbility(1);
            keyTemp = KeyCode.V;
        }
        else if (Input.GetKey(KeyCode.B))
        {
            // Chuyển sang khả năng thứ hai trong danh sách
            SetCurrentAbility(2);
            keyTemp = KeyCode.B;
        }
        ActivateAbility(currentAbility, keyTemp);

    }
    public void ActivateAbility(AbilityBase abi,KeyCode key)
    {
        switch (state)
        {
            case AbilityState.ready:

                if (Input.GetKeyDown(key))
                {
                    abi.Activate(this.gameObject);
                    state = AbilityState.active;
                    activeTime = abi.activeTime;
                }
                break;
            case AbilityState.active:

                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    abi.BeginCoolDown(gameObject);
                    state = AbilityState.cooldown;
                    coolDownTIme = abi.coolDownTime;    
                }
                break;
            case AbilityState.cooldown:

                if (coolDownTIme > 0)
                {
                    coolDownTIme -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;

                }
                break;
        }
    }
    void SetCurrentAbility(int index)
    {
        if (index >= 0 && index < abilities.Length)
        {
            currentAbility = abilities[index];
        }
    }

}
