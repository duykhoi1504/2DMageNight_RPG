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
    [SerializeField] GameObject respawn;

    [SerializeField] VectorValue playerPos;
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
        if (PlayerController.Instant.health <= 0f)
        {
            PlayerController.Instant.health += 1f;

            AudioManager.Instant.PlayMusic(CONSTANT.gameOver);

            playerPos.posValue= PlayerController.Instant.transform.position;
            Time.timeScale = 0;
            respawn.SetActive(true);
           
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
    public void ReSpawn()
    {
        respawn.SetActive(false);
        PlayerController.Instant.statusDefault();
        PlayerController.Instant.transform.position=playerPos.posValue;
        Time.timeScale = 1;
        AudioManager.Instant.PlayMusic(CONSTANT.theme);


       

    }

}
