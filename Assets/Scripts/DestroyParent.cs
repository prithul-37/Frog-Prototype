using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.parent.gameObject);
    }
}

