using System.Collections;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float destroyTime;
    public void destroyGameObj()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
