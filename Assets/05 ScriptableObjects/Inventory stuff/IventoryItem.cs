using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName ="New Item", menuName ="Iventory/Items")]
public class IventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDesciption;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;
    public void USe()
    {
       
            thisEvent.Invoke();
        Debug.Log("using  " + itemName);

    }
    public void DecreaseAmount(int amounttoDecrease) 
    {

        numberHeld-=amounttoDecrease;
        if(numberHeld < 0 )
        {
            numberHeld = 0;
        }
    }
}
