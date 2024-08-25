using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public event Action Shooted = delegate { };
    public static event Action<int> UpdateScore = delegate { };
    public static event Action playerdied = delegate { };
    public static event Action levelCompleted = delegate { };
    bool down = false;

    //scoring system
    private float playerInitialPos;

    //Audios
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip failed;
    [SerializeField] AudioClip landing;


    private void Start()
    {
        playerInitialPos = transform.transform.position.z;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            AudioManager.instance.playClip(landing, transform, 1);
            UpdateScore?.Invoke((int)transform.transform.position.z - (int)playerInitialPos);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            //print("GG");
            AudioManager.instance.playClip(landing, transform, 1);
            AudioManager.instance.playClip(failed,transform,1);
            playerdied?.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndTrigger")
        {
            print("win");
            AudioManager.instance.playClip(win, transform, 1);
            levelCompleted?.Invoke();
        }
    }
    private void OnMouseDown()
    {
        down = true;
    }

    private void OnMouseUp()
    {   
        if(down)
        {
            Shooted?.Invoke();
            down = false;
        }
    }

}
