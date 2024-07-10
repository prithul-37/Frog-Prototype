using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public event Action Shooted = delegate { };
    public static event Action<int> UpdateScore = delegate { };
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
