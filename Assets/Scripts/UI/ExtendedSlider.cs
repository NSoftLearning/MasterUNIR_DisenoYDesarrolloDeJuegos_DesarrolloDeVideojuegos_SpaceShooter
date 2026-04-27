using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtendedSlider : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TMP_Text _text;

    [SerializeField] AudioMixer _audioMixer;

    [SerializeField] string _audioParameterName;

    private void Start()
    {
        float startingValue;
        _audioMixer.GetFloat(_audioParameterName, out startingValue);
        startingValue = Mathf.Clamp(startingValue, -50, 20);
        startingValue = startingValue + 50;


        _slider.SetValueWithoutNotify ( startingValue / 70);
    }

    public void Refresh (float newValue)
    {
        _text.text = Mathf.RoundToInt(newValue * 100) + " %";
        _audioMixer.SetFloat(_audioParameterName, Mathf.Lerp(-50, 20, newValue));
    }


}
