using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    // Start is called before the first frame update
    [SerializeField] PlayerData _playerData;
    float currentHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = PlayerController.Instant.health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            if (currentHealth == 8f) return;
            PlayerController.Instant.health += _Heart;
            this.gameObject.SetActive(false);
        }
    }
}
