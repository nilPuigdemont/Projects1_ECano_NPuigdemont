using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider slider;

    public void Start()
    {
        slider.value = -20f;
    }
    public void SetVolume(float volume)
    {
        
        audioMixer.SetFloat("Volume", volume);

    }
}
