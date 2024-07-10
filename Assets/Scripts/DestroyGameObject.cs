using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float destroyTime = 1f;

    private void Start()
    {
        StartCoroutine(destroyy());

    }

    IEnumerator destroyy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
