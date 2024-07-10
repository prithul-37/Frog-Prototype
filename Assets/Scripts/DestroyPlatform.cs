using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float destroyTime = 3f;
    

    private void Start()
    {
        var lvlManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
        if (lvlManager != null)
        {
            destroyTime = lvlManager.pDestroyTime;
        }
    }
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
