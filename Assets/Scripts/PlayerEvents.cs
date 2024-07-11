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

    private void Start()
    {
        playerInitialPos = transform.transform.position.z;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            UpdateScore?.Invoke((int)transform.transform.position.z - (int)playerInitialPos);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            //print("GG");
            playerdied?.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndTrigger")
        {
            //print("win");
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
