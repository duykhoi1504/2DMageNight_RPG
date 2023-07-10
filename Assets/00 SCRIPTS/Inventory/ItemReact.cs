using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReact : MonoBehaviour
{
    // Start is called before the first frame update
   public void UseHealthPotion(float amount)
    {   
        PlayerController.Instant.health += amount;
        if (PlayerController.Instant.health >= PlayerController.Instant.PlayerData.Health)
            PlayerController.Instant.health = PlayerController.Instant.PlayerData.Health;
    }
    public void UseManaPotion(float amount)
    { 
        PlayerController.Instant.mana += amount;
        if (PlayerController.Instant.mana >= PlayerController.Instant.PlayerData.mana)
            PlayerController.Instant.mana = PlayerController.Instant.PlayerData.mana;
    }
}
