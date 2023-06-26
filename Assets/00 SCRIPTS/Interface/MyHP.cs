using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyHP : EnemyController
{
    [SerializeField]Slider slider;
    private void Start()
    {
        
    }
    private void Update()
    {
        slider.value = Health;
    }


}
