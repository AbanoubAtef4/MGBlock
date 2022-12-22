using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class setting : MonoBehaviour
{
    AudioSource ad;
    float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }
    public AudioMixer audiosound;
    // Update is called once per frame
    void Update()
    {
        ad.volume = volume;
    }

    public void setvolume(float v)
    {
        volume=v;
    }
}
