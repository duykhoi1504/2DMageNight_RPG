using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpBar : MonoBehaviour
{
    public Transform HPBarData;
    public Slider slider;

    private void FixedUpdate()
    {

        UpdateHpBar();
    }
    protected virtual void UpdateHpBar()
    {
        if (this.slider == null) return;
        PowerUpInterfave hpBarInterFace=this.HPBarData.GetComponent<PowerUpInterfave>();
        if(hpBarInterFace == null) return;
        this.slider.value = hpBarInterFace.HP();
    }
}
