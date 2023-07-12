using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : PowerUp
{
    // Start is called before the first frame update
    [SerializeField] float amoutCoin;
    [SerializeField] Inventory _inventory;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            AudioManager.Instant.PLaySFX(CONSTANT.coin);

            _inventory.coin += amoutCoin;
      

            this.gameObject.SetActive(false);
        }
    }
}
