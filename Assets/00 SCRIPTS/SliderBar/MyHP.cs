using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float hp;
   [SerializeField] EnemyController e;
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] Slider slider;
    void Start()
    {
        
        slider.maxValue= _enemyHealth.Health;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp);
        hp = e.Health;
        slider.value = hp;
    }
   
}
