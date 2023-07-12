using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    //float timeCount = 0;
    void Start()
    {
        Time.timeScale= 1.0f;
        //AudioManager.Instant.PlayMusic("VillageTheme");
    }

    // Update is called once per frame
    void Update()
    {
     


        //if (timeCount >= 5)
        //{
        //    Vector2 ranPos = new Vector2(
        //        Random.Range(-10, 10),
        //        Random.Range(-10, 10)
        //        );
        //    Instantiate(enemyPrefab, ranPos, Quaternion.identity);
        //    timeCount = 0;

        //}

    }
}
