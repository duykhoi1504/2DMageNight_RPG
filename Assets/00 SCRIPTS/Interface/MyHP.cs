using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyHP : MonoBehaviour,PowerUpInterfave
{
    public static float currentHP = 100;
    
   public  float HP()
    {
        return currentHP;
    }
  

}
