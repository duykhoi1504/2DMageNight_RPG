using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashImpact : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Material flash;
    [SerializeField] Material normal;
    [SerializeField]float delay;
    SpriteRenderer _sprite;
    void Start()
    {
        _sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            SpriteRenderer sprite1 = other.GetComponentInChildren<SpriteRenderer>();
            if (sprite1 != null)
            {
                Debug.Log(other.gameObject.name);
                sprite1.material = flash;

                StartCoroutine(FlashCo(sprite1));
            }
        }
    }
    private IEnumerator FlashCo(SpriteRenderer sp)
    {
        yield return new WaitForSeconds(2f);
        sp.material = normal;

    }
}
