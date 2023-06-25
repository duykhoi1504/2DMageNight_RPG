using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    [SerializeField] GameObject about;
    [SerializeField] GameObject setting;

    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene("MAIN");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenAbout()
    {
        about.SetActive(true);
    }
    public void ExitAbout()
    {
        about.SetActive(false);

    }
    public void OpenSetting()
    {
        setting.SetActive(true);
    }
    public void ExitSetting()
    {
        setting.SetActive(false);
    }

}
