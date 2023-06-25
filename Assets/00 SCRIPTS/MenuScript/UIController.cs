using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider _musicSlider, _sfxSlider;
    public void SFXVolume()
    {
        AudioManager.Instant.SFXVolume(_sfxSlider.value);
    }
    public void MusicVolume()
    {
        AudioManager.Instant.MusicVolume(_musicSlider.value);
    }
}
