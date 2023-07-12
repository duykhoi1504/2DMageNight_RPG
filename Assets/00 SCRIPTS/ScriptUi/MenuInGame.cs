using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject menu;
    [SerializeField] GameObject setting;
    [SerializeField] GameObject inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instant.PLaySFX(CONSTANT.menuOpen);
            menu.SetActive(true);
            Time.timeScale = 0;
         
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AudioManager.Instant.PLaySFX(CONSTANT.menuOpen);

            Time.timeScale = 0;
            //Animator imageAnimator= inventory.GetComponentInChildren<Animator>();
            //imageAnimator.enabled = true;
            inventory.SetActive(true);
            

         

        }

    }
    public void PauseGame()
    {

        Time.timeScale = 0;
    }

    public void Resume()
    {
        AudioManager.Instant.PLaySFX(CONSTANT.menuClose);

        Time.timeScale = 1;
        menu.SetActive(false);

    }
    public void OpenSetting()
    {
        setting.SetActive(true);
    }
    public void CloseSetting()
    {
        AudioManager.Instant.PLaySFX(CONSTANT.menuClose);

        setting.SetActive(false);
    }
    public void CloseInventory()
    {
        AudioManager.Instant.PLaySFX(CONSTANT.menuClose);

        Time.timeScale = 1;

        inventory.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MENU");
    }
  
}
