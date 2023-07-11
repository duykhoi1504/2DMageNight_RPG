using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBase : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] float _speed;
    float _countTime;
    [SerializeField] float _maxTime;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        _countTime = _maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    public void Fire()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 dir = ((Vector2)mouse - (Vector2)transform.position).normalized;
        
        rig.velocity = dir* _speed;

        _countTime -= Time.deltaTime;

        if (_countTime < 0)
        {
            this.gameObject.SetActive(false);
            _countTime = _maxTime;
        }
    }
  
}
