using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    
    public PlayerData _playerData;
    //public FloatValue _playerAmout;
    //public  float _amountToIncrease;W

    public void TimeOut(float time)
    { 
        StartCoroutine(DisappearCo(time));
    }
    IEnumerator DisappearCo(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}

