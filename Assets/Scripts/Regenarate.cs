using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenarate : MonoBehaviour
{
    public GameObject en;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Instantiate(en, new Vector3(transform.position.x,transform.position.y,transform.position.z+80), Quaternion.identity);
            gameObject.SetActive(false);
        }
    }



}
