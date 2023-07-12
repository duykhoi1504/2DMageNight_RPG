using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{
    // Start is called before the first frame update

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStorage.posValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
