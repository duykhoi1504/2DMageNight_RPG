using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBase : ScriptableObject
{
    public string name;
    public float coolDownTime;
    public float activeTime;

    
    public virtual void Activate(GameObject parent)
    {
       
    }
    public virtual void BeginCoolDown(GameObject parent)
    {

    }
    
}
