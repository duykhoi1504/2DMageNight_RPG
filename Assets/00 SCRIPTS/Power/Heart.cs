using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    // Start is called before the first frame update
    [SerializeField] float _amoutHeart = 2f;
    float currentHealth;
    [Header("time to disappear")]
    [SerializeField] float timeDis;
    void Start()
    {
        TimeOut(timeDis);
    }

    // Update is called once per frame
    void Update()
    {

        currentHealth = PlayerController.Instant.health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
           

            if (currentHealth == _playerData.Health) return;
            AudioManager.Instant.PLaySFX(CONSTANT.loop);
            TextPoupManger.Instant.gameObject.GetComponent<TextPoupManger>().getTextPoupPositive(collision.gameObject, _amoutHeart, Color.red);
            PlayerController.Instant.health += _amoutHeart;
            this.gameObject.SetActive(false);
           
        }
    }

}
