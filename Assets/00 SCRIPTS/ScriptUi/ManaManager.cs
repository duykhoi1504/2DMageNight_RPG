using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public PlayerData _playerData;
    public Slider _slider;
    [SerializeField] Text TextPlace;
    void Start()
    {
        _slider.maxValue = _playerData.mana;

    }

    // Update is called once per frame
    void Update()
    {

        _slider.value = PlayerController.Instant.mana ;
        TextPlace.text= _slider.value.ToString()+"/"+ _slider.maxValue.ToString();

    }
}
