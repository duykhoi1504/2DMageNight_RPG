using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
