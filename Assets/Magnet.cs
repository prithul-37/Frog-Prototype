using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Magnet : MonoBehaviour
{
    public float redius;
    public LayerMask mask;
    void Start()
    {
        var coliders = Physics.OverlapSphere(transform.position,redius,mask);

        foreach (var col in coliders)
        {
            if(col.gameObject.tag == "Coin")
            {
                col.gameObject.GetComponent<GotoPlayer>().GOToPlayer(GetComponentInParent<Transform>());
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position,redius);
    }

}
