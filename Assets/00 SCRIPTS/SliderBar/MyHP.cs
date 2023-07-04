using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]EnemyBase _enemy;
    [SerializeField] Slider _slider;
    void Start()
    {
        _enemy=GetComponent<EnemyBase>();
        _slider.maxValue = _enemy.MaxHealth;
        

    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _enemy.Health;
        //hp = e.Health;
        //slider.value = hp;
    }
   
}
