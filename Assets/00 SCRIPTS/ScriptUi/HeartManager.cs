using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public PlayerData _playerData;
    public FloatValue _heartContainer;
    void Start()
    {
        InitHearts();
    }
     void Update()
    {
        UpdateHearts();
    }
    // Update is called once per frame
    public void InitHearts()
    {
        for(int i=0;i< _heartContainer.initialValue;i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    public void UpdateHearts()
    {
        float tempHeart = PlayerController.Instant.health / 2;
        
        for(int i=0;i< _heartContainer.initialValue; i++)
        {
            
            if (i <= tempHeart - 1)
            {
                Debug.Log(i);
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHeart)
            {
                Debug.Log(i);

                hearts[i].sprite = emptyHeart;
            }
            else
            {
                Debug.Log(i);

                hearts[i].sprite = halfHeart;
            }
            Debug.Log(i + " " + tempHeart);
        }
    }
}
