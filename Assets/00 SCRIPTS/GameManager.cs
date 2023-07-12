using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] ParticleSystem rainDrop;
    [SerializeField] ParticleSystem rainRipples;
   [SerializeField] float randomTime;

    [SerializeField]float timeCount = 0;
    //float timeCount = 0;
    void Start()
    {
        EndRain();
        Time.timeScale= 1.0f;
        randomTime = Random.Range(20, 30);
        //AudioManager.Instant.PlayMusic("VillageTheme");
    }

    // Update is called once per frame
    void Update()
    {


        timeCount += Time.deltaTime;

        if (timeCount >= randomTime && timeCount < randomTime * 2)
        {
            StartRain();
        }
        else if (timeCount >= randomTime * 2)
        {
            EndRain();
            timeCount = 0;
            randomTime = Random.Range(1, 10);
        }


    }
    public void StartRain()
    {

        if (!rainDrop.isPlaying)
        {
            rainDrop.Play();
        }

        if (!rainRipples.isPlaying)
        {
            rainRipples.Play();
        }

    }
    public void EndRain()
    {

        if (rainDrop.isPlaying)
        {
            rainDrop.Stop();
        }

        if (rainRipples.isPlaying)
        {
            rainRipples.Stop();
        }

    }
}
