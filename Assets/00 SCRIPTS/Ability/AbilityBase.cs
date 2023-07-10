using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    public string name;
    public float coolDownTime;
    public float activeTime;
    public virtual void Activate(GameObject parent)
    {
    
    }
}
