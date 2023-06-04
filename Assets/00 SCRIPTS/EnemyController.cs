using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerGun;
    void Start()
    {
         playerGun = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir=this.transform.position- playerGun.transform.position;
    }
}
