using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound_controller : MonoBehaviour
{
    public Slider slider;
    float volume = 1f;
     GameObject soundmanager;
     AudioSource audiosound;

    void Start()
    {

        volume = PlayerPrefs.GetFloat("volume");

        soundmanager = GameObject.FindWithTag("sound");

        audiosound = soundmanager.GetComponent<AudioSource>();

        audiosound.volume = volume;

        slider.value = volume;

    }


    void Update()
    {

        audiosound.volume = volume;

        PlayerPrefs.SetFloat("volume", volume);
    }
    public void setVolume(float v)
    {

        volume = v;
    }


}

