using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioSFXobj; 

    private void Awake()
    {   
        if(instance == null)
            instance = this;
    }


    public void playClip(AudioClip audio,Transform spawnTransform,float volume)
    {
        AudioSource audioSource = Instantiate(audioSFXobj,transform.position,Quaternion.identity);
        audioSource.clip = audio;
        audioSource.volume = volume;
        audioSource.Play();
        float cliplength = audioSource.clip.length;
        Destroy(audioSource.gameObject,cliplength);
    }
}
