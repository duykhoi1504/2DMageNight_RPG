using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager :MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instant;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource,sfxSource;
    private void Awake()
    {
        if(Instant == null)
        {
            Instant = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        // Duyệt qua từng button và gán hàm xử lý sự kiện click cùng với âm thanh
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PLaySFX("click"));
        }


        AudioManager.Instant.PlayMusic(CONSTANT.theme);
    }
    public void PlayMusic(string name)
    {
        Sound s = null;
        foreach (Sound sound in musicSounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
       
    }
    public void PLaySFX(string name)
    {
        Sound s = null;
        foreach (Sound sound in sfxSounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }

        if (s == null)
        {
            Debug.Log("sfx not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
        //Sound s = Array.Find(sfxSounds, x => x.name == name);
        //if (s == null)
        //{
        //    Debug.Log("Sound not Found");
        //}
        //else
        //{
        //    sfxSource.PlayOneShot(s.clip);
        //}
    }
    public void MusicVolume(float volumn)
    {
        musicSource.volume = volumn;
    }
    public void SFXVolume(float volumn)
    {
        sfxSource.volume = volumn;  
    }
}
