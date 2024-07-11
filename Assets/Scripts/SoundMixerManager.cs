using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void setMasterVolume(float level)
    {
        audioMixer.SetFloat("MASTERv",Mathf.Log10(level)*20f);
    }

    public void setMusicVolume(float level)
    {
        audioMixer.SetFloat("MUSICv", Mathf.Log10(level) * 20f);
    }

    public void setSFXVolume(float level)
    {
        audioMixer.SetFloat("SFXv", Mathf.Log10(level) * 20f);
    }

}
