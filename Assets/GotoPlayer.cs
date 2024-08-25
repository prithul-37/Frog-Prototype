using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoPlayer : MonoBehaviour
{   
    bool go = false;
    Transform playerTransform;
    bool once = true;
    private void FixedUpdate()
    {
        if(go)
        {
            transform.position = Vector3.MoveTowards(transform.position,playerTransform.position,Time.deltaTime*20);
        }   
    }

    public void GOToPlayer(Transform playerTransform)
    {   
        if(once)
        {this.playerTransform = playerTransform;
            go = true;
            once = false;
        }
    }
}
