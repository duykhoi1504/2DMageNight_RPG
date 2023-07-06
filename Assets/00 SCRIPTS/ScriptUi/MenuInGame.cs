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
        if (Input.GetKey(KeyCode.Escape))
        {

            menu.SetActive(true);
            Time.timeScale = 0;
         
        }
        if (Input.GetKey(KeyCode.Tab))
        {
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
        Time.timeScale = 1;
        menu.SetActive(false);

    }
    public void OpenSetting()
    {
        setting.SetActive(true);
    }
    public void CloseSetting()
    {
        
        setting.SetActive(false);
    }
    public void CloseInventory()
    {
        Time.timeScale = 1;

        inventory.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MENU");
    }
  
}
