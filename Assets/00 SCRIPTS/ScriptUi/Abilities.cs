using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class AbilityUI 
{
    public AbilityBase _ability;
    public Image _imageAbility;
}

public class Abilities : MonoBehaviour
{
    [Header("Ability")]
    public  AbilityUI[] abilityList;
     float coolDown ;
    bool isCoolDown = false;



    KeyCode keyCodeTemp;
    int tempIndex;

    void Start()
    {
        foreach (AbilityUI _ui in abilityList)       {
            _ui._imageAbility.fillAmount = 0;
        }
        //abilityImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            keyCodeTemp = KeyCode.LeftShift;
            tempIndex= 0;
        
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            keyCodeTemp = KeyCode.V;
            tempIndex = 1;
            
        }
        Ability(keyCodeTemp, tempIndex);
    }
 
    void Ability(KeyCode ability, int index)
    {
        coolDown = abilityList[index]._ability.coolDownTime;
        if (Input.GetKey(ability)&& isCoolDown==false)
        {
            isCoolDown = true;
            abilityList[index]._imageAbility.fillAmount = 1;
        }
        if (isCoolDown)
        {
            abilityList[index]._imageAbility.fillAmount -= 1 / coolDown * Time.deltaTime;
            if(abilityList[index]._imageAbility.fillAmount<= 0 )
            {
                abilityList[index]._imageAbility.fillAmount = 0;
                isCoolDown= false;
            }
        }
    }

}
